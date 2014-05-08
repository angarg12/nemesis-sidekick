using UnityEngine;
using System.Collections;

public class PlayerFaction : Faction {
	public ParticleSystem explosion;
	public Material myMaterial;

	public override void destroy(GameObject orderer){
		if(orderer.tag == "enemy"){
			Destroy(gameObject);
			ParticleSystem explosionInstance = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
			explosionInstance.renderer.material = myMaterial;
		}
	}
}
