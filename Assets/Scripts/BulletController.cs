using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float speed;

	void Start () {
		rigidbody2D.velocity = transform.up * speed;
	}
}
