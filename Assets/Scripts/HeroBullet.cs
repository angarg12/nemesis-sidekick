using UnityEngine;
using System.Collections;

public class HeroBullet : BulletController, IFactioned {
	
	private Faction.Color color = Faction.Color.Blue;
	
	public Faction.Color getColor(){
		return color;
	}
}
