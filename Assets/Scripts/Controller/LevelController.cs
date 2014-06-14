using UnityEngine;
using System.Collections;

public abstract class LevelController: MonoBehaviour {
	public GameMode mode {get; protected set;}
	public Boundary playersBoundary = new Boundary();
	public Boundary screen = new Boundary();

	public abstract void playerKilled(PlayerController player);
	public abstract void playerEliminated(PlayerController player);
	
	protected void setup(){
		adjustToResolution ();
	}

	// Adjust the following elements to the current resolution.
	// - Camera
	// - Boundaries
	// - Respawn point
	private void adjustToResolution(){
		Camera camera = Camera.main;
		camera.orthographicSize = (Screen.height / 2.0f) / (float)Constants.PIXELS_PER_UNIT;

		screen.xMax = camera.orthographicSize*camera.aspect;
		screen.xMin = -camera.orthographicSize*camera.aspect;
		screen.yMax = camera.orthographicSize;
		screen.yMin = -camera.orthographicSize;

		playersBoundary.xMax = screen.xMax-0.5f;
		playersBoundary.xMin = screen.xMin+0.5f;
		playersBoundary.yMax = screen.yMax-1f;
		playersBoundary.yMin = screen.yMin+0.5f;

		GameObject boundaryObject = GameObject.Find ("Boundary");
		boundaryObject.transform.localScale = new Vector3 (
			screen.xMax * 2f + 2f,
			screen.yMax * 2f + 2f,
			0f);

		GameObject externalBoundaryObject = GameObject.Find ("ExternalBoundary");
		externalBoundaryObject.transform.localScale = new Vector3 (
			screen.xMax * 2f + 4f,
			screen.yMax * 2f + 4f,
			0f);

		GameObject heroSpawn = GameObject.Find ("Hero Spawn");
		heroSpawn.transform.position = new Vector3 (
			-2f,
			screen.yMin,
			0f);

		GameObject sidekickSpawn = GameObject.Find ("Sidekick Spawn");
		sidekickSpawn.transform.position = new Vector3 (
			2f,
			screen.yMin,
			0f);
	}

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
