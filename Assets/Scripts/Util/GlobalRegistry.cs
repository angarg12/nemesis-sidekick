using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

/*
 * Global registry of classes in the system. This registry is used to support the extensible and scriptable
 * data of the game, and enables mods and plug-ins.
 * 
 * The registry stores three variables: namespace, key and value. Namespaces allow to separate variables based on their
 * semantics.
 * 
 * They values stored are classes, and are used by the game to instantiate new entities on the game.
 * 
 * For safety the class provides two methods to store values, put and putAndOvewrite. Regular put fails if the same key
 * already exists on the same namespace.
 */


public class GlobalRegistry {
	static Dictionary<string, Dictionary<string, string>> registry = new Dictionary<string, Dictionary<string, string>> ();

	static GlobalRegistry(){
		UnityEngine.Object[] assets = Resources.LoadAll ("");
		List<TextAsset> bindings = new List<TextAsset> ();
		foreach (UnityEngine.Object asset in assets) {
			if(Regex.IsMatch(asset.name,@".*\.bindings$")){
				bindings.Add((TextAsset)asset);
			}
		}

		foreach (TextAsset bindingFile in bindings) {
			Dictionary<string, string> properties = JsonConvert.DeserializeObject<Dictionary<string, string>> (bindingFile.text);
			foreach (string key in properties.Keys) {
				put (bindingFile.name.Replace(".bindings",""), key, properties [key]);
			}
		}
	}

	// Puts the key in the registry, but fails if it is already set.
	public static void put(string namespace_, string key, string value){
		if (registry.ContainsKey (namespace_) == false) {
			registry.Add(namespace_, new Dictionary<string, string>());
		}
		registry [namespace_].Add (key, value);
	}
	
	// Puts the key, overwritting the value if it exists.
	public static void putAndOvewrite(string namespace_, string key, string value){
		if (registry.ContainsKey (namespace_) == false) {
			registry.Add(namespace_, new Dictionary<string, string>());
		}
		registry [namespace_][key] = value;
	}
	
	// Gets the key.
	public static string get(string namespace_, string key){
		return registry[namespace_][key];
	}
	
	// Deletes the key.
	public static void delete(string namespace_, string key){
		registry[namespace_].Remove(key);
	}

	private List<String> findBindingFiles(string directory){
		List<String> files = new List<String>();
		foreach (string f in Directory.GetFiles(directory)) {
			Regex.IsMatch(f,"*.binding");
			files.Add(f);
		}
		foreach (string d in Directory.GetDirectories(directory)) {
			files.AddRange(findBindingFiles(d));
		}
		
		return files;
	}
}
