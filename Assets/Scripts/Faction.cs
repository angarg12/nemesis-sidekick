using UnityEngine;
using System.Collections;

public class Faction: MonoBehaviour {
	public FactionController.Color color;
	public int attackPower;
	public int life;

	public FactionController.Color getColor(){
		return color;
	}

	public virtual void damage(GameObject orderer){
		Faction other = orderer.GetComponent<Faction>();
		life -= other.attackPower;
		if(life <= 0){
			kill(orderer);
		}
	}

	public virtual void kill(GameObject orderer){}
}
