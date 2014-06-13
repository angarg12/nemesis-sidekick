using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	void OnGUI () {
		GUI.skin.button.wordWrap = true;
		if(GUI.Button(
			new Rect(
				(Screen.width-200)/2-110,
				(Screen.height-500)/2,
				200,
				400), 
			"Nemesis mode\n " +
			"Competitive game.")){
			SceneVariables.putVariable(SceneVariables.Variable.LevelPath,"NemesisLevels");
			Application.LoadLevel("LevelMenu");
		}
		if(GUI.Button(
			new Rect(
				(Screen.width-200)/2+110,
				(Screen.height-500)/2,
				200,
				400), 
			"Sidekick mode\n " +
			"Cooperative game\n " +
			"Friendly fire is enabled.")){
			SceneVariables.putVariable(SceneVariables.Variable.LevelPath,"SidekickLevels");
			Application.LoadLevel("LevelMenu");
		}
		if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+350)/2,100,50), "Quit")){
			Application.Quit();
		}
	}
}
