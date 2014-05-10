using UnityEngine;
using System.Collections;

public class DeathBuff : IBuff {
	private static DeathBuff instance;
	
	private DeathBuff() {}
	
	public static DeathBuff Instance {
		get {
			if (instance == null) {
				instance = new DeathBuff();
			}
			return instance;
		}
	}

	public void Apply(PlayerController player){
		player.fireRate -= 0.2f;
	}

	public void Unapply(PlayerController player){
		player.fireRate += 0.2f;
	}
}
