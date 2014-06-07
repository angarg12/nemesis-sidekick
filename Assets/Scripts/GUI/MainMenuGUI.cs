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
			"Competitive game.")){
			SceneVariables.putVariable(SceneVariables.Variable.LevelPath,"./Assets/Scenes/NemesisLevels/Levels.json");
			Application.LoadLevel("LevelMenu");
		}
		if(GUI.Button(
			new Rect(
				(Screen.width-200)/2+200,
				(Screen.height-500)/2,
				200,
				400), 
			"Sidekick mode\n " +
			"Cooperative game\n " +
			"Friendly fire is enabled.")){
			SceneVariables.putVariable(SceneVariables.Variable.LevelPath,"./Assets/Scenes/SidekickLevels/Levels.json");
			Application.LoadLevel("LevelMenu");
		}
		if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+200)/2,100,50), "Quit")){
			Application.Quit();
		}
	}
}
