using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffTracker {
	private Dictionary<IBuff, int> buffs = new Dictionary<IBuff, int>();

	private bool isCached = false;
	private string stringValue = null;

	public void addBuff(IBuff buff){
		if (buffs.ContainsKey (buff)) {
			buffs [buff] += 1;		
		} else {
			buffs [buff] = 1;	
		}
		isCached = false;
	}
	
	public void removeBuff(IBuff buff){
		if (buffs.ContainsKey (buff)) {
			buffs [buff] -= 1;	
			if(buffs[buff] == 0){
				buffs.Remove(buff);
			}
		}
		isCached = false;
		// FIXME: Should we log at least a warning if the key is not found?.
	}

	public string getStringValue(){
		if (isCached == false) {
			generateSnapshot();
			isCached = true;
		}
		return stringValue;
	}

	private void generateSnapshot(){
		string buffList = "";
		foreach(KeyValuePair<IBuff, int> entry in buffs) {
			// do something with entry.Value or entry.Key
			buffList += entry.Key.ToString();
			if(entry.Value > 1){
				buffList += "*"+entry.Value;
			}
			buffList += " ";
		}
		if (buffList.Length > 0) {
			stringValue = buffList;
		}
	}
}
