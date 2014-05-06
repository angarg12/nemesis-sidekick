using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		Faction myFaction = transform.GetComponent<Faction>();
		Faction otherFaction = other.GetComponent<Faction>();
		if(otherFaction != null){
			// If we are not on the same category, destroy the other
			if(gameObject.tag != other.tag){
				// If we can damage each other, destroy myself
				if(FactionController.Damages(otherFaction.getColor(), myFaction.getColor())){
					Destroy(gameObject);
				}
				otherFaction.destroy(gameObject);
			}
		}
	}
}
