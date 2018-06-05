using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital {
	public class PlayerMovement : MonoBehaviour {

		public float flySpeed = 1f;
		public float groundedSpeed = 1f;

		PhysicsAttractant physics;
		public PhysicsAttractant Physics {
			get { return physics; }
		}

		bool isGrounded;

		// Use this for initialization
		void Start() {
			physics = GetComponent<PhysicsAttractant>();
		}

		// Update is called once per frame
		void Update() {
			Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),
										Input.GetAxisRaw("Vertical"));
			if (isGrounded) {
				PlayerGrounded.Move(this, input);
			} 
			else {
				PlayerFlying.Move(this, input);
			}
		}

		void OnPhysicsCollisionEnter(PhysicsCollider other) {
			if (other.CompareTag("Terrain")) { //hit planet
				physics.attractionActive = false;
				isGrounded = true;
			}
		}

		void OnPhysicsCollisionExit(PhysicsCollider other) {
			if (other.CompareTag("Terrain")) {
				physics.attractionActive = true;
				isGrounded = false;
			}
		}
	}
}

