using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Orbital
{
	public class PhysicsAttractant : PhysicsBody
	{

		public bool attractionActive = true;

		void Update()
		{
			if (attractionActive)
				acceleration += Gravity.Instance.GetGravForceOn(this);
		}
	}
}
