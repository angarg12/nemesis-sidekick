using UnityEngine;
using System.Collections;

public static class FactionController {

	public enum Color {
		Blue,
		Red,
		Purple
	}

	public static bool Damages(Color source, Color target){
		if( source != target){
			return true;
		}
		return false;
	}
}
