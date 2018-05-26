using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Orbital
{

	public class CollisionSystem : Singleton<CollisionSystem>
	{
		protected CollisionSystem() { } //Singleton

		protected struct CollisionInfo {
			readonly PhysicsCollider col1;
			readonly PhysicsCollider col2;

			public CollisionInfo(PhysicsCollider l, PhysicsCollider r) {
				col1 = l;
				col2 = r;
			}

			public static bool operator == (CollisionInfo l, CollisionInfo r) {
				return (l.col1.Equals(r.col1) && l.col2.Equals(r.col2)) ||
					(l.col1.Equals(r.col2) && l.col2.Equals(r.col1));
			}

			public static bool operator != (CollisionInfo l, CollisionInfo r) {
				return !(l == r);
			}

			public override bool Equals(object obj)
			{
				return obj is CollisionSystem && this == (CollisionInfo)obj;
			}

			public override int GetHashCode()
			{
				return col1.GetHashCode() ^ col2.GetHashCode();
			}
		}

		//Collision atlas
		private HashSet<CollisionInfo> atlas;

		private List<PhysicsCollider> cols;
		public void RegisterCollider(PhysicsCollider collider) {
			cols.Add(collider);
		}
		public void RemoveCollider(PhysicsCollider collider) {
			cols.Remove(collider);
		}

		private void Awake()
		{
			atlas = new HashSet<CollisionInfo>();
			cols = new List<PhysicsCollider>();
		}

		void Update() {
			//check each collider pair for collisions
			for (int l = 0; l < cols.Count; l++) {
				for (int r = l + 1; r < cols.Count; r++) {
					PhysicsCollider lcol = cols[l];
					PhysicsCollider rcol = cols[r];

					CollisionInfo info = new CollisionInfo(lcol, rcol);
					if (lcol.Overlapping(rcol))
					{
						if (atlas.Contains(info))
						{
							//continuous collision
							lcol.SendMessage("OnPhysicsCollisionStay", rcol,
											 SendMessageOptions.DontRequireReceiver);
							rcol.SendMessage("OnPhysicsCollisionStay", lcol,
											 SendMessageOptions.DontRequireReceiver);
						}
						else
						{
							//new collision
							atlas.Add(info);
							lcol.SendMessage("OnPhysicsCollisionEnter", rcol,
				 							 SendMessageOptions.DontRequireReceiver);
							rcol.SendMessage("OnPhysicsCollisionEnter", lcol,
											 SendMessageOptions.DontRequireReceiver);
						}
					}
					else if (atlas.Contains(info)) {
						//collision ended
						atlas.Remove(info);
						lcol.SendMessage("OnPhysicsCollisionExit", rcol,
										SendMessageOptions.DontRequireReceiver);
						rcol.SendMessage("OnPhysicsCollisionExit", lcol,
										SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}
}
