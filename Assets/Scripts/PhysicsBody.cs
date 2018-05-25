using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Custom Physics system for Orbital game
namespace Orbital
{
	public abstract class PhysicsBody : MonoBehaviour
	{

		[SerializeField] protected float mass = 1f;
		public float Mass
		{
			get
			{
				return mass;
			}
		}

		[SerializeField] protected float mu = 0.05f;

		protected Vector2 velocity;
		protected Vector2 acceleration;

		void Start()
		{
			velocity = Vector2.zero;
			acceleration = Vector2.zero;
		}

		private void LateUpdate()
		{
			//acceleration += Gravity.Instance.GetGravForceOn(this);

			velocity += acceleration;
			transform.position += new Vector3(velocity.x, velocity.y);
			acceleration = Vector2.zero;
			velocity = Vector2.Lerp(velocity, Vector2.zero, mu);
		}

		public void AddForce(Vector2 force)
		{
			//F = M * A
			//A = F / M
			acceleration += force / mass;
		}

		public void Stop()
		{
			velocity = Vector2.zero;
			acceleration = Vector2.zero;
		}

		//private void OnCollisionEnter2D(Collision2D collision) {

		//}

	}
}
