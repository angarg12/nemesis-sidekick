using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin; 
	public float xMax; 
	public float yMin;
	public float yMax;
}

public class HeroController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	
	public BulletFaction shotPrefab;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	
	void Update (){
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			BulletFaction shotInstance = (BulletFaction)Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
			shotInstance.setParent(gameObject);
			//audio.Play ();
		}
	}
	
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;

		transform.position = new Vector3(
			Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax), 
			Mathf.Clamp (transform.position.y, boundary.yMin, boundary.yMax),
			0.0f
			);
	}
}