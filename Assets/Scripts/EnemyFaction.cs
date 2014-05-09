using UnityEngine;
using System.Collections;

public class EnemyFaction : Faction {
	public ParticleSystem explosion;
	public Material myMaterial;

	public override void damage(GameObject orderer){
		if(orderer.tag != "enemy"){
			base.damage(orderer);
		}
	}

	public override void kill(GameObject orderer){
		// Add score to the killer, directly or indirectly through the bullet
		// I don't like this code as there is a sensible amount of repetition, with BulletFaction also.
		if(orderer.GetComponent<PlayerController>() != null){
			orderer.GetComponent<PlayerController>().addScore(value);
		}else if(orderer.GetComponent<BulletFaction>() != null){
			orderer.GetComponent<BulletFaction>().addScore(value);
		}

		Destroy(gameObject);
		ParticleSystem explosionInstance = (ParticleSystem)Instantiate(
			explosion, 
			transform.position, 
			transform.rotation);
		// Need to customize the explosion material for each faction
		explosionInstance.renderer.material = myMaterial;
		explosionInstance.Play();
	}
}
