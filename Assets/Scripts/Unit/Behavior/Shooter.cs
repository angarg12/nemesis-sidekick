using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public BulletFaction shotPrefab;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public AudioClip fireAudio;

	// FIXME: Is there a better method to prevent the audio from playing multiple times than
	// using an static variable?
	// suggestion: A less-hacky version might be a tiny serialized class for each sound: audioClip, 
	// noPlaySecs and lastPlayedTime. Then a play member function to check lastPlayedTime ... . 
	// But would have to pass in your audioSource or init a static. -  Owen Reynolds 
	float audioPlayDelay = 0.2f;
	static float LastTimeFired = 0f;

	void Start () {
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire () {
		BulletFaction shotInstance = (BulletFaction)Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
		shotInstance.setFather(gameObject);
		if (Time.time > LastTimeFired + audioPlayDelay) {
			AudioSource audio = GameObject.FindWithTag ("GameController").GetComponent<AudioSource> ();
			audio.PlayOneShot (fireAudio, 0.2F);
			LastTimeFired = Time.time;
		}
	}
}
