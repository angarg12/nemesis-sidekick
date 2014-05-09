using UnityEngine;
using System.Collections;

public class BulletFaction : Faction {
	GameObject father;

	public void setFather(GameObject theFather){
		father = theFather;
	}

	public override void damage(GameObject orderer){
		kill(orderer);
	}

	public override void kill(GameObject orderer){
		Destroy (gameObject);
	}

	public void addScore(int score){
		if(father != null && 
		   father.GetComponent<PlayerController>() != null){
			father.GetComponent<PlayerController>().addScore(score);
		}
	}
}
