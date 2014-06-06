using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	void OnGUI () {
		GUI.skin.button.wordWrap = true;
		if(GUI.Button(
			new Rect(
				(Screen.width-200)/2-200,
				(Screen.height-500)/2,
				200,
				400), 
			"Nemesis mode\n " +
			"Competitive game\n " +
			"Score 2000 total points and be the last player alive to win.")){
			Application.LoadLevel("NemesisTest");
		}
		if(GUI.Button(
			new Rect(
				(Screen.width-200)/2+200,
				(Screen.height-500)/2,
				200,
				400), 
			"Sidekick mode\n " +
			"Cooperative game\n " +
			"Friendly fire is enabled\n " +
			"Score 5000 total combined points and survive both players to win.")){
			Application.LoadLevel("SidekickTest");
		}
		if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+200)/2,100,50), "Quit")){
			Application.Quit();
		}
	}
}
