using UnityEngine;
using System.Collections;

public abstract class LevelController: MonoBehaviour {
	public abstract void playerKilled(GameObject player);
	public abstract void playerEliminated(GameObject player);
	public abstract void pauseGame();
	public abstract void unpauseGame();
}
