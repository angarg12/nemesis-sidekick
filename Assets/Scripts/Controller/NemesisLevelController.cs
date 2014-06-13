using UnityEngine;
using System.Collections;

public class NemesisLevelController : LevelController {
	public int targetIndividualScore;

	public PlayerController hero;
	public PlayerController sidekick;

	private GameState state;
	private int playersRemaining = 2;

	protected new void setup(){
		base.setup ();
	}

	void Start(){
		setup ();
		mode = GameMode.Nemesis;
		state = GameState.Started;
		Time.timeScale = 1;
	}

	// Los objetivos varian segun el modo de juego. Para simplificar vamos a hacer lo siguiente.
	// En modo sidekick ambos deben sobrevivir y tener una puntuacion combinada de X.
	// En modo nemesis, debe sobrevivir solo uno de ellos, y tener una puntuacion individual de Y.
	void Update () {
		if(state == GameState.Started){
			if(hero != null && 
			   hero.score >= targetIndividualScore && 
			   playersRemaining == 1){
				showWinWindow("Hero");
			}
			if(sidekick != null && 
			   sidekick.score >= targetIndividualScore && 
			   playersRemaining == 1){
				showWinWindow("Sidekick");
			}
			if(Input.GetKeyDown(KeyCode.Escape)) {
				LevelGUI gui = GameObject.Find("GUI").GetComponent<LevelGUI>();
				if(gui != null){
					gui.paused = !gui.paused;
				}
			}
		}
	}

	void showWinWindow(string winner){
		LevelGUI gui = GameObject.Find("GUI").GetComponent<LevelGUI>();
		if(gui != null){
			gui.winMessageLabel = winner+" wins!!";
			gui.win = true;
		}
		state = GameState.Win;
		disableLevel();
	}

	// Used to apply buff or anything in general.
	public override void playerKilled(PlayerController player){
		// Apply the death buff, only if he has lives left!
		if (player.lives > 0) {
			if (hero != null && 
				player.tag == hero.tag) {
				DeathBuff.Instance.Apply (hero);
			} else if (sidekick != null &&
				player.tag == sidekick.tag) {
				DeathBuff.Instance.Apply (sidekick);
			}
		}
	}

	public override void playerEliminated(PlayerController player){
		if(state == GameState.Started){
			playersRemaining--;
			if(playersRemaining <= 0){
				LevelGUI gui = GameObject.Find("GUI").GetComponent<LevelGUI>();
				if(gui != null){
					gui.lose = true;
				}
				state = GameState.Lose;
				disableLevel();
			}
		}
	}
}
