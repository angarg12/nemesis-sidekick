using UnityEngine;

public class Boundary {
	public float xMin; 
	public float xMax; 
	public float yMin;
	public float yMax;

	public Vector3 trimToBoundary(float x, float y){
		return new Vector3(
			Mathf.Clamp (x, xMin, xMax), 
			Mathf.Clamp (y, yMin, yMax),
			0.0f
		);
	}

	//Translates one point in the boundary to one point in the world.
	// (0,0) is the upper left corner and (1,1) is the lower right one.
	public Vector3 boundaryToWorld(float x, float y){
		return new Vector3 (
			(xMax-xMin)*x+xMin,
			(yMin-yMax)*y+yMax,
			0f);
	}
}