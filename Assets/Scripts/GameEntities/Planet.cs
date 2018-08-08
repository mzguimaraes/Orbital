using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital {
	[RequireComponent(typeof(PhysicsCollider), typeof(PhysicsAttractor))]
	public class Planet : MonoBehaviour {
		//utility class

		public PlayerMovement PlayerOn { get; protected set; } //TODO: won't work in multiplayer (needs to be array)

		public PhysicsCollider Collider { get; protected set; }

		public PhysicsAttractor Attractor { get; protected set; }

		private void Start() {
			Collider = GetComponent<PhysicsCollider>();
			Attractor = GetComponent<PhysicsAttractor>();
		}

		private void OnDrawGizmos() {
			if (PlayerOn) {
				Vector2 contactPt = Phys.GetContactPoint(PlayerOn.Collider as CirclePhysicsCollider,
													 	 Collider as CirclePhysicsCollider);

				Gizmos.color = Color.red;

				Gizmos.DrawSphere(contactPt, .5f);

				Gizmos.color = Color.yellow;

				Gizmos.DrawLine(contactPt, contactPt + Collider.GetNormalAtPoint(contactPt));

				Gizmos.DrawLine(contactPt, contactPt + Vector2.Perpendicular(Collider.GetNormalAtPoint(contactPt)));
			}
		}

		private void OnPhysicsCollisionEnter(PhysicsCollider other) {
			Debug.Log("Player entering planet");
			PlayerOn = other.GetComponent<PlayerMovement>();
		}

		private void OnPhysicsCollisionExit(PhysicsCollider other) {
			if (PlayerOn && other.GetComponent<PlayerMovement>()) {
				Debug.Log("Player leaving planet");
				PlayerOn = null;
			}
		}
	}
}
