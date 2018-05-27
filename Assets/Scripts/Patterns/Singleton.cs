using System.Linq;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

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
				GameObject singleton = new GameObject();
				_instance = singleton.AddComponent<T>();
				singleton.name = "Singleton Game Object"; //todo: find a way to name it after T
				DontDestroyOnLoad(singleton);
			}
			return _instance;
		}
	}

	void OnDestroy()
	{
		isApplicationQuitting = true;
	}
}
