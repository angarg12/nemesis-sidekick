using UnityEngine;
using System.Collections;

public class HeroFaction : Faction {
	public GameObject explosion;

	public override void destroy(GameObject orderer){
		if(orderer.tag == "enemy"){
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
		}
	}
}
