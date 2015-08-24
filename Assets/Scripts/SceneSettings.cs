using UnityEngine;
using System.Collections;

public class SceneSettings : MonoBehaviour {

	public string mainGhost;

	// Use this for initialization
	void Start () {
		mainGhost = "TB";
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp (KeyCode.Keypad1)) {
			mainGhost = "TB";
		}
		if (Input.GetKeyUp (KeyCode.Keypad2)) {
			mainGhost = "JS";
		}
		if (Input.GetKeyUp (KeyCode.Keypad3)) {
			mainGhost = "JC";
		}
		if (Input.GetKeyUp (KeyCode.Keypad4)) {
			mainGhost = "Do";
		}

	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
