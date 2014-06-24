using UnityEngine;
using System.Collections;

public class MovementCircle : Movement {
	public class Direction {
		public float x;
		public float y;
	}
	
	public Direction direction;
	public float radius;
	// Speed in rotations per second. Positive is counterclockwise rotation, negative clockwise.
	public float speed;
	private float runningTime = 0;

	//Fix initial angle
	public override IEnumerator execute(GameObject entity){
		Vector2 circleCenter = calculateCircleCenter (entity);
		float angularSpeed = (2 * Mathf.PI) * speed;
		float initialAngle = calculateInitialAngle();
		float angle;
		while (runningTime < duration) {
			angle = angularSpeed*runningTime+initialAngle;
			entity.transform.position = new Vector2(
				circleCenter.x+Mathf.Cos(angle)*radius,
				circleCenter.y+Mathf.Sin(angle)*radius);
			float before = Time.time;
			yield return new WaitForSeconds (Time.deltaTime);
			float after = Time.time;
			runningTime += after-before;
		}
	}

	private Vector2 calculateCircleCenter(GameObject entity){
		Vector2 normalizedDirection = new Vector2 (direction.x, direction.y).normalized;
		Vector2 entityPosition = new Vector2 (entity.transform.position.x, entity.transform.position.y);
		return entityPosition + normalizedDirection*radius;
	}

	private float calculateInitialAngle(){
		Vector2 xAxis = Vector2.right;
		// We need the vector that points from the center of the circle to the position of the entity.
		Vector2 inverseDirection = new Vector2 (-direction.x, -direction.y);
		float angleRadians = Vector2.Angle (xAxis, inverseDirection) * Mathf.PI / 180;
		// The angle function only returns a value between 0 and PI radians. We need to use the cross product
		// to know if it is between PI and 2*PI.
		Vector3 cross = Vector3.Cross(xAxis, inverseDirection);
		if (cross.z < 0) {
			angleRadians = 2*Mathf.PI - angleRadians;
		}
		return angleRadians;
	}
}
