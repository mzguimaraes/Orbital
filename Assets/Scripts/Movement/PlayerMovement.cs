using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital {
	public class PlayerMovement : MonoBehaviour {

		public float flySpeed = 1f;
		public float groundedSpeed = 1f;

		public PhysicsCollider Collider {
			get; protected set;
		}

		PhysicsAttractant physics;
		public PhysicsAttractant Physics {
			get { return physics; }
		}

		public Vector2 Position {
			get {
				return new Vector2(transform.position.x, transform.position.y);
			}
		}

		//bool isGrounded;
		Planet onPlanet = null;

		// Use this for initialization
		void Start() {
			physics = GetComponent<PhysicsAttractant>();
			Collider = GetComponent<PhysicsCollider>();
		}

		// Update is called once per frame
		void Update() {
			Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),
										Input.GetAxisRaw("Vertical"));
			if (onPlanet) {
				PlayerGrounded.Move(this, input, onPlanet);
			} 
			else {
				PlayerFlying.Move(this, input);
			}
		}

		void OnPhysicsCollisionEnter(PhysicsCollider other) {
			if (other.CompareTag("Terrain")) { //hit planet
				if (onPlanet == null) {
					Debug.Log("Hit planet");
					physics.attractionActive = false;
					physics.Stop();
					onPlanet = other.GetComponent<Planet>();
				} else { //squished between planets
					//TODO: kill player (probably a different script tho)
				}
			}
		}

		void OnPhysicsCollisionExit(PhysicsCollider other) {
			if (other.CompareTag("Terrain")) {
				Debug.Log("Left planet");
				physics.attractionActive = true;
				onPlanet = null;
			}
		}
	}
}

