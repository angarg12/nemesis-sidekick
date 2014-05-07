using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	
	public BulletFaction shotPrefab;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	public string FireButton = "";
	public string HorizontalAxis = "";
	public string VerticalAxis = "";
	
	void Update (){
		if (Input.GetButton(FireButton) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		}
	}
	
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis (HorizontalAxis);
		float moveVertical = Input.GetAxis (VerticalAxis);
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;
		
		transform.position = new Vector3(
			Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax), 
			Mathf.Clamp (transform.position.y, boundary.yMin, boundary.yMax),
			0.0f
			);
	}
}