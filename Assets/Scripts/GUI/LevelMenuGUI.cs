using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

public class LevelMenuGUI : MonoBehaviour {
	Level[] levels;

	void Start(){
		// How we could enable loading plugin levels: add a path were level json are dropped,
		// and then scan that folder and load whatever level files are present.
		DebugUtils.Assert(SceneVariables.hasVariable(SceneVariables.Variable.LevelPath), 
		                  "Variable "+SceneVariables.Variable.LevelPath+" not set correctly.");
		string levelsFile = SceneVariables.getAndDeleteVariable (SceneVariables.Variable.LevelPath);

		TextAsset fileContent = Resources.Load<TextAsset>(levelsFile);
		levels = JsonConvert.DeserializeObject<Level[]>(fileContent.text);
	}

	void OnGUI () {
		string levelDescription = "";
		GUILayout.BeginArea (
			new Rect(
				(Screen.width-200)/2-200,
				(Screen.height-500)/2,
				600,
				600));
		GUILayout.BeginHorizontal ();

		foreach(Level level in levels){
			if(GUILayout.Button(level.DisplayName, GUILayout.Height(40), GUILayout.Width(40))){
				Application.LoadLevel(level.Name);
			}
			// What a convoluted way to implement the onHover function. Keep an eye for if they ever simplify this.
			if(Event.current.type == EventType.Repaint &&
			   GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition )){
				levelDescription = level.Description;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();

		// This box contains the description of the level. It changes as you hover over level buttons.
		GUI.skin.box.wordWrap = true;
		GUI.Box(
			new Rect(
				(Screen.width-250),
				(Screen.height-500)/2,
				200,
				400), 
			levelDescription);
		// Back to main menu
		if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+200)/2,100,50), "Back")){
			Application.LoadLevel("MainMenu");
		}
	}
}
