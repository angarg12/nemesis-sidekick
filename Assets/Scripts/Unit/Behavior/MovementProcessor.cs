using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

using System; using System.Reflection;

public class MovementProcessor : MonoBehaviour {
	Movement[] movements;

	void Start () {
		TextAsset fileContent = Resources.Load<TextAsset>("EnemyMovement");
		movements = JsonConvert.DeserializeObject<Movement[]>(fileContent.text, new MovementItemConverter());
		StartCoroutine(process());
	}

	IEnumerator process () {
		foreach (Movement movement in movements) {
			yield return StartCoroutine(movement.execute(gameObject));
		}
		enabled = false;
	}
}
