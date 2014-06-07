using System.Collections.Generic;

/*
 * This is an utility class for keeping variables between scenes. A very ugly, but arguably best way to do it.
 * Since using global variables is ugly and error-prone, two 'safety' methods have been implemented, beside the two
 * 'regular' ones for storing and retrieving variables.
 * 
 * They key idea is the following: this script will be used mostly to pass variables between scenes, in a one-write,
 * one-read fashion. The problem is that if an script reads an old variable, he may not know it, and the problem doesn't
 * become evident.
 * 
 * One example goes like this.
 * - Scene 1 sets variable A.
 * - Scene 2 reads variable A.
 * - Scene 3 SHOULD set variable A, but doesn't.
 * - Scene 4 reads variable A thinking that 3 set it, but he is oblivious of the error.
 * 
 * Using the 'safe' methods, we can check that variables are only read and set once. That way we can quickly spot 
 * mistakes of the following form:
 * 
 * - An script tries to use a variable which value wasn't set.
 * - An script tries to override a variable which value hasn't been read yet.
 */
public class SceneVariables {
	public enum Variable {
		LevelPath
	}

	static Dictionary<Variable, string> variables = new Dictionary<Variable, string> ();

	// Puts the variable in the dictionary, but fails if it is already set.
	public static void putVariable(Variable key, string value){
		variables.Add (key, value);
	}

	// Puts the variable, overwritting the value if it exists.
	public static void putAndOverwriteVariable(Variable key, string value){
		variables[key] = value;
	}

	// Gets the variable, and lets it stay in the dictionary.
	public static string getVariable(Variable key){
		return variables [key];
	}

	// Gets the variable, and deletes it from the dictionary.
	public static string getAndDeleteVariable(Variable key){
		string value = variables [key];
		variables.Remove(key);
		return value;
	}

	public static bool hasVariable(Variable key){
		return variables.ContainsKey (key);
	}
}
