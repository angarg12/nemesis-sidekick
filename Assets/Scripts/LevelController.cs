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
		// FIXME: This also disables the boundaries, so that the last items aren't destroyed.
		Collider2D[] colliders = (Collider2D[])Object.FindObjectsOfType(typeof(Collider2D));
		foreach(Collider2D collider in colliders){
			collider.enabled = false;
		}

		// FIXME: A little bug may occur when the game is won or lost when a players is in movement. He just goes out of boundaries.
		PlayerController[] players = (PlayerController[])Object.FindObjectsOfType(typeof(PlayerController));
		foreach(PlayerController player in players){
			player.enabled = false;
		}

		WaveSpawnerController waveSpawner = (WaveSpawnerController)Object.FindObjectOfType(typeof(WaveSpawnerController));
		Destroy(waveSpawner);
	}
}
