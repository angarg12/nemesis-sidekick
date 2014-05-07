using UnityEngine;
using System.Collections;

public class BulletFaction : Faction {
	public override void destroy(GameObject orderer){
		Destroy (gameObject);
	}
}
