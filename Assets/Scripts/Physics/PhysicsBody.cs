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

		public PhysicsCollider Collider {
			get; protected set;
		}

		protected Vector2 velocity;
		protected Vector2 acceleration;

		void Start()
		{
			velocity = Vector2.zero;
			acceleration = Vector2.zero;
			Collider = GetComponent<PhysicsCollider>();
		}

		private void LateUpdate()
		{
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

	}
}
