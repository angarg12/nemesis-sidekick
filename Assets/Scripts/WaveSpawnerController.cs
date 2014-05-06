using UnityEngine;
using System.Collections;

public class WaveSpawnerController : MonoBehaviour {
	public GameObject[] enemies;
	public float spawnRate;
	public float delay;

	void Start () {
		InvokeRepeating ("SpawnEnemy", delay, spawnRate);
	}
	
	// Update is called once per frame
	void SpawnEnemy () {
		Vector3 position = gameObject.transform.position;
		position.x = Random.Range(-7.5f,7.5f);
		Instantiate(enemies[(Random.Range(0, enemies.Length))], position, gameObject.transform.rotation);
	}
}
