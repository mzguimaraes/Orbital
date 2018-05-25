using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Orbital
{
	public class PhysicsAttractant : PhysicsBody
	{

		void Update()
		{
			acceleration += Gravity.Instance.GetGravForceOn(this);
		}
	}
}
