using UnityEngine;
using System;
using System.Collections;

public class WaveSpawnerController : MonoBehaviour {
	public GameObject[] enemies;
	public float spawnRate;
	public float delay;

	void Start () {
		InvokeRepeating ("SpawnEnemy", delay, spawnRate);
	}

	void SpawnEnemy () {
		// Spawn enemies at a random location in the horizontal axis
		Vector3 position = gameObject.transform.position;
		position.x = UnityEngine.Random.Range(-7.5f,7.5f);
		int enemyType = UnityEngine.Random.Range (0, enemies.Length);
		EnemyFaction enemy = ((GameObject)Instantiate(enemies[enemyType], position, gameObject.transform.rotation)).GetComponent<EnemyFaction>();
		// A very convoluted way to pick up a valid random color from the enum
		FactionController.FactionColor enemyColor = (FactionController.FactionColor)(UnityEngine.Random.Range (1, Enum.GetNames (typeof(FactionController.FactionColor)).Length));
		enemy.colorize (enemyColor);
	}
}
