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
	public int score = 0;

	private float nextFire;
	public string FireButton = "";
	public string HorizontalAxis = "";
	public string VerticalAxis = "";

	private bool isDead = false;
		
	void FixedUpdate(){
		if(isDead == false){
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
		
		if(isDead == false &&
		   Input.GetButton(FireButton) && 
		   Time.time > nextFire){
			nextFire = Time.time + fireRate;
			BulletFaction shotInstance = (BulletFaction)Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
			shotInstance.setFather(gameObject);
			//audio.Play ();
		}
	}

	public IEnumerator death(){
		isDead = true;
		lives--;
		LevelController level = GameObject.FindWithTag("GameController").GetComponent<LevelController>();
		level.playerKilled(gameObject);

		int respawnTime = 2;
		int invincibilityTime = 1;

		if(lives > 0){
			// Turn off the renderer to make the object invisible
			StartCoroutine(makeInvencible(respawnTime+invincibilityTime));
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(respawnTime);
			gameObject.transform.position = spawnPoint.position;
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			isDead = false;
		}else{
			Destroy(gameObject);
			level.playerEliminated(gameObject);
		}
	}

	public IEnumerator makeInvencible(float seconds){
		collider2D.enabled = false;

		float transparent = 0.3f;
		float opaque = 1f;
		float blinkRate = 0.1f;

		Color playerColor = renderer.material.color;
			while(seconds > 0){
			playerColor.a = transparent;
			renderer.material.color = playerColor;
			yield return new WaitForSeconds(blinkRate);
			seconds -= blinkRate;
			playerColor.a = opaque;
			renderer.material.color = playerColor;
			yield return new WaitForSeconds(blinkRate);
			seconds -= blinkRate;
		}
		collider2D.enabled = true;
	}

	public void addScore(int addScore){
		score += addScore;
	}
}