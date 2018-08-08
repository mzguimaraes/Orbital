using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital
{
	public class CirclePhysicsCollider : PhysicsCollider
	{

		public bool autoRadius = false;
		public float radius = 0.5f; //ratio of diameter

		public override Vector2 Center
		{
			get
			{
				return new Vector2(transform.position.x, transform.position.y) 
									+ offset;
			}
		}

		public override Vector2 GetNormalAtPoint(Vector2 point, bool givenAsOffset = false) {
			if (givenAsOffset) {
				point += Center;
			}

			float d = Vector2.Distance(Center, point);
			if (d > radius) {
				Debug.LogError("Point provided not on circle collider\nPoint: " + 
				               point.ToString() + "\nCircle collider: " + 
				               Center.ToString() + " " + radius.ToString() + 
				               "\nDistance: " + d);
			}
			return (point - Center) / d;
		}

		public override Vector2 GetOverlapVector(PhysicsCollider other) {
			//returns a vector pointing away from other collider
			if (other is CirclePhysicsCollider) {
				if (!Overlapping(other)) return Vector2.zero;
				Vector2 dist = Center - ((CirclePhysicsCollider)other).Center;
				return dist * (radius + ((CirclePhysicsCollider)other).radius - dist.magnitude);
			} else {
				throw new System.NotImplementedException();
			}
		}

		public override bool Overlapping(PhysicsCollider other)
		{
			if (other is CirclePhysicsCollider) {
				
				Vector2 btwn = other.Center - Center;
				float r = radius + ((CirclePhysicsCollider)other).radius;
				return Vector2.SqrMagnitude(btwn) <= r * r;
			}
			else {
				throw new System.NotImplementedException();
			}
		}

		protected override void DrawWireframe() {
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(new Vector3(Center.x, Center.y, 0), radius);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (autoRadius) {
				radius = transform.localScale.x / 2;
			}
		}

	}
}
