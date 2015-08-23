using UnityEngine;
using System.Collections;

public class SceneChangeOnDeath : MonoBehaviour {

	public GameObject Target;
	public float ChangeTime = 5f;
	public int LevelToLoad = 1;
	
	// Update is called once per frame
	void LateUpdate () {
		if (!Target) {
			Invoke ("SceneChange", ChangeTime);
		}
	}

	void SceneChange () {
		Application.LoadLevel (LevelToLoad);
	}
}
