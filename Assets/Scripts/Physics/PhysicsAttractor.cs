using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital
{
	public class PhysicsAttractor : PhysicsBody
	{

		private void Start()
		{
			Gravity.Instance.AddAttractor(this);
		}

		private void OnDisable()
		{
			Gravity.Instance.RemoveAttractor(this);
		}

		public Vector2 GetGravForce(PhysicsBody obj)
		{
			//f = g(m1 * m2) / (r * r)

			float r = Vector2.Distance(obj.transform.position, transform.position);
			Vector2 force = Gravity.G * (transform.position - obj.transform.position);
			force *= (Mass * obj.Mass) / (r * r);

			return force;
		}

	}
}
