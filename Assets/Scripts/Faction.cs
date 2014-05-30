using UnityEngine;
using System.Collections;

public class Faction: MonoBehaviour {
	public FactionController.FactionColor color = FactionController.FactionColor.Unknown;
	public int attackPower = 1;
	public int life = 1;
	public int value = 0;

	public virtual void Awake(){
		if (color != FactionController.FactionColor.Unknown) {
			colorize(color);
		}
	}

	public virtual void colorize(FactionController.FactionColor color_){
		color = color_;
		Color colorChange = FactionController.toRGB[color];
		renderer.material.color = colorChange;
	}

	public FactionController.FactionColor getColor(){
		DebugUtils.Assert(color != FactionController.FactionColor.Unknown, "Factions must have a color assigned.");
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
