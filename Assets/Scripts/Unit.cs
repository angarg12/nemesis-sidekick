using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		Faction myFaction = transform.GetComponent<Faction>();
		Faction otherFaction = other.GetComponent<Faction>();
		if(otherFaction != null){
			if(FactionController.Damages(otherFaction.getColor(), myFaction.getColor())){
				Destroy(gameObject);
				Destroy(other.gameObject);
			}
		}
	}
}
