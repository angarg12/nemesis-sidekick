using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {
	public GUIStyle style;

	public PlayerController hero;
	public PlayerController sidekick;

	void OnGUI () {
		GUI.Label (new Rect (20,10,100,50), "Hero", style);
		GUI.Label (new Rect (20,30,100,50), "Lives: "+hero.lives, style);
		GUI.Label (new Rect (20,50,100,50), "Points: 0", style);

		
		GUI.Label (new Rect (Screen.width - 150,10,100,50), "Sidekick", style);
		GUI.Label (new Rect (Screen.width - 150,30,100,50), "Lives: "+sidekick.lives, style);
		GUI.Label (new Rect (Screen.width - 150,50,100,50), "Points: 0", style);
	}
}
