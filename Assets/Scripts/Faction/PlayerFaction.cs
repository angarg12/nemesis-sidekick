using UnityEngine;
using System.Collections;

public class PlayerFaction : UnitFaction {	
	public override void damage(GameObject orderer){
		LevelController levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
		if(orderer.tag == "enemy"){
			base.damage(orderer);
		// If we are in sidekick mode, enable friendly fire
		}else if(levelController.mode == GameMode.Sidekick &&
		         orderer.tag != gameObject.tag){
			base.damage(orderer);
		}
	}

	public override void kill(GameObject orderer){
		ParticleSystem explosionInstance = (ParticleSystem)Instantiate(
			explosion, 
			transform.position, 
			transform.rotation);
		explosionInstance.renderer.material = myMaterial;
		explosionInstance.Play();
		
		AudioSource audio = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
		audio.PlayOneShot(deathAudio, 1F);

		PlayerController player = gameObject.GetComponent<PlayerController>();
		player.StartCoroutine(player.death());
	}
}
