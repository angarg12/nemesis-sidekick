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
		Destroy(gameObject);
		ParticleSystem explosionInstance = (ParticleSystem)Instantiate(
			explosion, 
			transform.position, 
			transform.rotation);
		explosionInstance.renderer.material = myMaterial;
		explosionInstance.Play();
	}
}
