using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbital
{
	public class Gravity : ScriptableObjectSingleton<Gravity>
	{

		readonly List<PhysicsAttractor> attractors = new List<PhysicsAttractor>();

		public void AddAttractor(PhysicsAttractor attractor)
		{
			attractors.Add(attractor);
		}

		public void RemoveAttractor(PhysicsAttractor attractor)
		{
			attractors.Remove(attractor);
		}

		const float _g = .5f; //gravitational constant -- can play with this
		public static float G
		{
			get
			{
				return _g;
			}
		}

		public Vector2 GetGravForceOn(PhysicsBody body)
		{
			Vector2 force = Vector2.zero;

			attractors.ForEach((PhysicsAttractor obj) =>
			{
				force += obj.GetGravForce(body); 
			});

			return force;
		}
	}
}
