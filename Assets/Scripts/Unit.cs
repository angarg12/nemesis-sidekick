using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		Faction myFaction = transform.GetComponent<Faction>();
		Faction otherFaction = other.GetComponent<Faction>();
		if(otherFaction != null){
			// If we are the same, ignore
			if(transform.tag == other.tag){
				return;
			}
			// If we can damage each other, damage each other
			if(FactionController.Damages(otherFaction.getColor(), myFaction.getColor())){
				myFaction.damage(other.gameObject);
			}
			// If the other is a bullet, damage it always
			if(other.GetComponent<BulletFaction>() != null){
				otherFaction.damage(gameObject);
			}
		}
	}
}
