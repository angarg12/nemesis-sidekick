using UnityEngine;
using System.Collections;

public abstract class LevelController: MonoBehaviour {
	public GameMode mode {get; protected set;}

	public abstract void playerKilled(PlayerController player);
	public abstract void playerEliminated(PlayerController player);

	public void pauseGame(){
		Time.timeScale = 0;
	}
	
	public void unpauseGame(){
		Time.timeScale = 1;
	}

	public void disableLevel(){
		PlayerController[] players = (PlayerController[])Object.FindObjectsOfType(typeof(PlayerController));
		foreach(PlayerController player in players){
			player.rigidbody2D.velocity = Vector2.zero;
			player.collider2D.enabled = false;
			player.enabled = false;
		}

		WaveSpawnerController waveSpawner = (WaveSpawnerController)Object.FindObjectOfType(typeof(WaveSpawnerController));
		Destroy(waveSpawner);
	}
}
