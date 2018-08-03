using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Orbital
{
	public abstract class PhysicsCollider : MonoBehaviour
	{
		public Vector2 offset = Vector2.zero;

		public abstract bool Overlapping(PhysicsCollider other); 

		public abstract Vector2 Center
		{
			get;
		}

		public abstract Vector2 GetNormalAtPoint(Vector2 point, bool givenAsOffset = false);

		protected virtual void OnEnable() {
			CollisionSystem.Instance.RegisterCollider(this);
		}

		protected virtual void OnDisable() {
			if (CollisionSystem.Instance)
				CollisionSystem.Instance.RemoveCollider(this);
		}

		protected abstract void DrawWireframe();

		protected void OnDrawGizmosSelected()
		{
			DrawWireframe();
		}

	}
}
