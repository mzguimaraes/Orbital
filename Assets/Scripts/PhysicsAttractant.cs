using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAttractant : PhysicsBody {

	void Update() {
		acceleration += Gravity.Instance.GetGravForceOn(this);
	}
}
