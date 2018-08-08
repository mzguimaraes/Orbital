using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital {
	public static class PlayerGrounded {

		public static void Move(PlayerMovement player, Vector2 input, Planet onPlanet) {
			//jump
			if (input.x > 0) {
				player.transform.Translate(input.x * onPlanet.Collider.GetNormalAtPoint(player.Position));
			}

			if (onPlanet.Collider is CirclePhysicsCollider) {
				CirclePhysicsCollider circleCollider = onPlanet.Collider as CirclePhysicsCollider;

				Vector2 contactPt = Phys.GetContactPoint(circleCollider, player.Collider as CirclePhysicsCollider);

				Vector2 perp = Vector2.Perpendicular(circleCollider.GetNormalAtPoint(contactPt));
				Debug.Log(perp);

				player.transform.Translate((input.y * perp));

			} else {
				throw new System.NotImplementedException();
			}
		}

	}
}
