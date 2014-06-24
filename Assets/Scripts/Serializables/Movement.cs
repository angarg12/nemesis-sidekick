using UnityEngine;
using System.Collections;

public abstract class Movement {
	public int duration = 0;
	public string type;

	public abstract IEnumerator execute(GameObject entity);
}
