using UnityEngine;
using System.Collections;

public class UnitFaction : Faction {
	public ParticleSystem explosion;
	public AudioClip deathAudio;
	public Material materialPrefab;
	protected Material myMaterial;
	
	public override void Awake(){
		// We need to clone the material. Otherwise whenever we change it, we are changing the prefab.
		myMaterial = new Material (materialPrefab);
		// FIXME: we need to call base.awake last because there are nasty dependences between awake and colorize
		// if we don't do this, myMaterial will be null in colorize
		base.Awake ();
	}
	
	public override void colorize(FactionController.FactionColor color_){
		base.colorize (color_);
		Color colorChange = FactionController.toRGB[color];
		myMaterial.color = colorChange;
	}
}
