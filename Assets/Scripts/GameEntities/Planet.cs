using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital {
	[RequireComponent(typeof(PhysicsCollider), typeof(PhysicsAttractor))]
	public class Planet : MonoBehaviour {
		//utility class

		public PhysicsCollider Collider { get; protected set; }

		public PhysicsAttractor Attractor { get; protected set; }

		private void Start() {
			Collider = GetComponent<PhysicsCollider>();
			Attractor = GetComponent<PhysicsAttractor>();
		}
	}
}
