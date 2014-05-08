using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	
	public BulletFaction shotPrefab;
	public Transform shotSpawn;
	public float fireRate;

	public Transform spawnPoint;
	public int lives = 3;

	private float nextFire;
	public string FireButton = "";
	public string HorizontalAxis = "";
	public string VerticalAxis = "";
	
	void Update(){
		if (Input.GetButton(FireButton) && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		}
	}
	
	void FixedUpdate(){
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

	public IEnumerator death(){
		lives--;
		// TODO: call the level controller to tell him a player died
		if(lives > 0){
			// Turn off the renderer to make the object invisible
			StartCoroutine(makeInvencible(4));
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(2);
			gameObject.transform.position = spawnPoint.position;
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			// TODO: apply invulnerability?
		}else{
			Destroy(gameObject);
			// TODO: call the level controller to tell him a player has been eliminated
		}
	}

	public IEnumerator makeInvencible(float seconds){
		gameObject.GetComponent<Collider2D>().enabled = false;
		Color playerColor = renderer.material.color;
			while(seconds > 0){
			playerColor.a = 0.3f;
			renderer.material.color = playerColor;
			yield return new WaitForSeconds(0.1f);
			seconds -= 0.1f;
			playerColor.a = 1f;
			renderer.material.color = playerColor;
			yield return new WaitForSeconds(0.1f);
			seconds -= 0.1f;
		}
		gameObject.GetComponent<Collider2D>().enabled = true;

	}
}