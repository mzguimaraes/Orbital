using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Orbital
{
	/*
	 * Library for commonly used physics interactions
	 */
	public class Phys : ScriptableObject
	{
		public static PhysicsBody Reflect(PhysicsBody body, PhysicsCollider other) {

			//Get vector from other to body (collision normal)
			Vector2 norm = other.Center - body.Collider.Center;

			//Reflect body velocity across normal

			return body;
		}

		public static Vector2 GetContactPoint(CirclePhysicsCollider lhs, CirclePhysicsCollider rhs) {
			return lhs.Center + ((rhs.Center - lhs.Center).normalized * lhs.radius);
		}

		//Vector2 contactPt = circleCollider.Center + ((player.Position - circleCollider.Center).normalized *
											 //((CirclePhysicsCollider)player.Collider).radius);

	}
}
