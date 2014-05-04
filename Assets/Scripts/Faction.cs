using UnityEngine;
using System.Collections;

public class Faction {

	public enum Color {
		Blue,
		Red,
		Purple
	}

	public bool Damages(Color source, Color target){
		if( source != target){
			return true;
		}
		return false;
	}
}
