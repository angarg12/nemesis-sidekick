using UnityEngine;
using System.Collections;

public class Faction: MonoBehaviour {

	public FactionController.Color color;

	public FactionController.Color getColor(){
		return color;
	}
}
