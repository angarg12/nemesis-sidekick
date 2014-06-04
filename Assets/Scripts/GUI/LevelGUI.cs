using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {
	public GUIStyle style;

	public PlayerController hero;
	public PlayerController sidekick;

	public bool win = false;
	public bool lose = false;
	public bool paused = false;

	public string winMessageLabel = "You win!!";

	void OnGUI () {
		GUI.Label (new Rect (20,10,100,50), "Hero", style);
		GUI.Label (new Rect (20,30,100,50), "Lives: "+hero.lives, style);
		GUI.Label (new Rect (20,50,100,50), "Score: "+hero.score, style);
		if (hero.getBuffsString() != null) {
			GUI.Label (new Rect (20, 70, 100, 50), "Buffs: " + hero.getBuffsString(), style);
		}
		
		GUI.Label (new Rect (Screen.width - 150,10,100,50), "Sidekick", style);
		GUI.Label (new Rect (Screen.width - 150,30,100,50), "Lives: "+sidekick.lives, style);
		GUI.Label (new Rect (Screen.width - 150,50,100,50), "Score: "+sidekick.score, style);
		if (sidekick.getBuffsString() != null) {
			GUI.Label (new Rect (Screen.width - 150,70,100,50), "Buffs: " + sidekick.getBuffsString(), style);
		}

		if(win){
			GUIStyle winStyle = new GUIStyle(style);
			winStyle.fontSize = 32;
			winStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect((Screen.width-100)/2,(Screen.height-50)/2,100,50), winMessageLabel, winStyle);
			
			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+70)/2,100,50), "Repeat")){
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+190)/2,100,50), "Quit")){
				Application.Quit();
			}
		}
		if(lose){
			GUIStyle loseStyle = new GUIStyle(style);
			loseStyle.fontSize = 32;
			loseStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect ((Screen.width-100)/2,(Screen.height-50)/2,100,50), "You lose", loseStyle);

			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+70)/2,100,50), "Retry")){
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+190)/2,100,50), "Quit")){
				Application.Quit();
			}
		}
		if(paused){		
			LevelController level = GameObject.FindWithTag("GameController").GetComponent<LevelController>();
			level.pauseGame();
			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height-50)/2,100,50), "Resume")){
				paused = false;
			}		
			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+70)/2,100,50), "Restart")){
				Application.LoadLevel(Application.loadedLevel);
				paused = false;
			}
			if(GUI.Button(new Rect((Screen.width-100)/2,(Screen.height+190)/2,100,50), "Main menu")){
				Application.LoadLevel("MainMenu");
				paused = false;
			}
		}else{
			LevelController level = GameObject.FindWithTag("GameController").GetComponent<LevelController>();
			level.unpauseGame();
		}
	}
}
