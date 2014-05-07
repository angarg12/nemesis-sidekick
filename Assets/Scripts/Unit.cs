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
			// If we can damage each other, destroy each other
			}else if(FactionController.Damages(otherFaction.getColor(), myFaction.getColor())){
				//Destroy(gameObject);
				// TODO: Implementar el resto de facciones.
				myFaction.destroy(other.gameObject);
				otherFaction.destroy(gameObject);
			// If the other is a bullet, destroy it always
			}else if(other.GetComponent<BulletFaction>() != null){
				otherFaction.destroy(gameObject);
			}
		}
	}
}
