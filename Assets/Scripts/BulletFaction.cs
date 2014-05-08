using UnityEngine;
using System.Collections;

public class BulletFaction : Faction {
	public override void damage(GameObject orderer){
		kill(orderer);
	}

	public override void kill(GameObject orderer){
		Destroy (gameObject);
	}
}
