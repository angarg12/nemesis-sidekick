using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public BulletFaction shotPrefab;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	
	void Start () {
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire () {
		BulletFaction shotInstance = (BulletFaction)Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
		shotInstance.setParent(gameObject);
		//audio.Play();
	}
}
