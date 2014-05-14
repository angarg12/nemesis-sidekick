using UnityEngine;
using System.Collections;

public abstract class LevelController: MonoBehaviour {
	public abstract void playerKilled(GameObject player);
	public abstract void playerEliminated(GameObject player);

	public void pauseGame(){
		Time.timeScale = 0;
	}
	
	public void unpauseGame(){
		Time.timeScale = 1;
	}

	public void disableLevel(){
		PlayerController[] players = (PlayerController[])Object.FindObjectsOfType(typeof(PlayerController));
		foreach(PlayerController player in players){
			player.rigidbody2D.velocity = new Vector2(0,0);
			player.collider2D.enabled = false;
			player.enabled = false;
		}

		WaveSpawnerController waveSpawner = (WaveSpawnerController)Object.FindObjectOfType(typeof(WaveSpawnerController));
		Destroy(waveSpawner);
	}
}
