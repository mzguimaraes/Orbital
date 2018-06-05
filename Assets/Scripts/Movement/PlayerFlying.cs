using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital {
	//[RequireComponent(typeof(PhysicsBody))]
	public static class PlayerFlying {

		//public static float speed = 1f;
		//private float currSpeed;
		//public float CurrSpeed {
		//	get { return currSpeed; }
		//}

		//bool grounded = false;

		//PhysicsBody physics;

		//private void Start() {
		//	physics = GetComponent<PhysicsBody>();
		//}

		//void Update() {
		//	var moveVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		//	moveVec *= Time.deltaTime * speed;
		//	physics.AddForce(moveVec);
		//	//transform.position += moveVec;
		//}

		public static void Move(PlayerMovement player, Vector2 input) {
			input *= Time.deltaTime * player.flySpeed;
			player.Physics.AddForce(input);
		}

		//private void OnCollisionEnter2D(Collision2D collision)
		//{
		//	if (collision.gameObject.CompareTag("Terrain"))
		//	{
		//		Debug.Log("Hit!");
		//		grounded = true;
		//		physics.Stop();
		//	}
		//}
	}
}
