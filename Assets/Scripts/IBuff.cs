using UnityEngine;
using System.Collections;

public interface IBuff {
	void Apply(PlayerController player);
	void Unapply(PlayerController player);
	string ToString();
}
