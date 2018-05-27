using System.Linq;
using UnityEngine;

public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject {

	//https://baraujo.net/unity3d-making-singletons-from-scriptableobjects-automatically/

	private static T _instance;

#pragma warning disable RECS0108 // Warns about static fields in generic types
	protected static bool isApplicationQuitting = false;
#pragma warning restore RECS0108 // Warns about static fields in generic types

	public static T Instance {
		get {
			if (isApplicationQuitting) return null;

			if (!_instance) {
				_instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
			}

			if (!_instance) {
				_instance = CreateInstance<T>();
			}

			return _instance;
		}
	}

	private void OnDestroy()
	{
		isApplicationQuitting = true;
	}
}
