using UnityEngine;
using System.Collections;

public class MovementLine : Movement {
	public class Direction {
		public float x;
		public float y;
	}

	public Direction direction;
	public float speed;

	public override IEnumerator execute(GameObject entity){
		Vector2 vector = new Vector2 (direction.x, direction.y);
		entity.rigidbody2D.velocity = vector * speed;
		yield return new WaitForSeconds(duration);
	}
}
