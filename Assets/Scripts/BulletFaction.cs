using UnityEngine;
using System.Collections;

public class BulletFaction : Faction {

	private GameObject parent;

	public void setParent(GameObject parent_){
		parent = parent_;
	}

	public override void destroy(GameObject orderer){
		/*
		 * NOTE: If the parent object is destroyed, the parent reference becomes null.
		 * Right now this isn't a problem because even if the parent died, the bullet must be 
		 * destroyed. Just in case it is necessary in the future, check if it isn't null.
		 */
		if(orderer != parent){
			Destroy (gameObject);
		}
	}
}
