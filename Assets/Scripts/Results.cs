using UnityEngine;

public class Results : MonoBehaviour {

	private static Results _instance;

	public static Results instance {
		get {
			if(_instance == null) {
				var go = new GameObject("Results");
				_instance = go.AddComponent<Results>();
				DontDestroyOnLoad(go);
			}

			return _instance;
		}
	}

	public uint topScore { get; set; } = 0;

	private void Awake() {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	private void OnDestroy() {
		if(_instance == this) {
			_instance = null;
		}
	}

}
