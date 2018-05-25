using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsBody))]
public class PlayerMovement : MonoBehaviour {

	public float speed = 1f;

	bool grounded = false;

	PhysicsBody physics;

	private void Start()
	{
		physics = GetComponent<PhysicsBody>();
	}

	// Update is called once per frame
	void Update () {
		var moveVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVec *= Time.deltaTime * speed;
		physics.AddForce(moveVec);
		//transform.position += moveVec;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Terrain")) {
			Debug.Log("Hit!");
			grounded = true;
			physics.Stop();
		}
	}
}
