using UnityEngine;
using System.Collections;

public class HeroFaction : Faction {
	public ParticleSystem explosion;
	public Material material;

	public void Start(){
		explosion.renderer.material = material;
	}

	public override void destroy(GameObject orderer){
		if(orderer.tag == "enemy"){
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
		}
	}
}
