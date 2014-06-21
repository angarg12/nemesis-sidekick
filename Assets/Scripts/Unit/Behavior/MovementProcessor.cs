using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class MovementProcessor : MonoBehaviour {
	Movement[] movements;

	void Start () {
		TextAsset fileContent = Resources.Load<TextAsset>("EnemyMovement");
		movements = JsonConvert.DeserializeObject<MovementLine[]>(fileContent.text);
		StartCoroutine(process());
	}

	IEnumerator process () {
		foreach (Movement movement in movements) {
			yield return StartCoroutine(movement.execute(gameObject));
		}
		enabled = false;
	}
}
