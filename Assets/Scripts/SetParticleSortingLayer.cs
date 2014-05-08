using UnityEngine;
using System.Collections;

public class SetParticleSortingLayer : MonoBehaviour {
	// The name of the sorting layer the particles should be set to.
	public string sortingLayerName;		
	
	void Start() {
		// Set the sorting layer of the particle system.
		particleSystem.renderer.sortingLayerName = sortingLayerName;
	}
}
