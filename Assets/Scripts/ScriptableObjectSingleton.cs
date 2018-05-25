using System.Linq;
using UnityEngine;

public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject {

	//https://baraujo.net/unity3d-making-singletons-from-scriptableobjects-automatically/

	private static T _instance;

	public static T Instance {
		get {
			if (!_instance) {
				_instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
			}

			if (!_instance) {
				_instance = CreateInstance<T>();
			}

			return _instance;
		}
	}
}
