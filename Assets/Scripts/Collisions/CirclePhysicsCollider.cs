﻿using System.Collections;
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

		public override bool Overlapping(PhysicsCollider other)
		{
			if (other is CirclePhysicsCollider) {
				
				Vector2 btwn = other.Center - Center;
				float r = radius + ((CirclePhysicsCollider)other).radius;
				return Vector2.SqrMagnitude(btwn) >= r * r;
			}
			else {
				throw new System.NotImplementedException();
			}
		}

		protected override void DrawWireframe() {
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(new Vector3(Center.x, Center.y, 0), radius);
		}

		protected override void Start()
		{
			base.Start();
			if (autoRadius) {
				radius = transform.localScale.x / 2;
			}
		}

	}
}