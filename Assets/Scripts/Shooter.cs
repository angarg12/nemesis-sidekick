using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public BulletFaction shotPrefab;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public AudioClip fireAudio;

	void Start () {
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire () {
		BulletFaction shotInstance = (BulletFaction)Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
		shotInstance.setFather(gameObject);
		AudioSource audio = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
		audio.PlayOneShot(fireAudio, 0.2F);
	}
}
