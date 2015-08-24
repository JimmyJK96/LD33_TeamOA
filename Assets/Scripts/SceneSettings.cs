using UnityEngine;
using System.Collections;

public class SceneSettings : MonoBehaviour {

	public string mainGhost;

	public GameObject[] Ghosts;
	public GameObject[] Characters;

	private int GC0;
	private int GC1;
	private int GC2;
	private int GC3;
	// Use this for initialization
	void OnLevelWasLoaded () {
		Debug.Log ("Durka durka");
		DontDestroyOnLoad(transform.gameObject);

		Ghosts [0] = GameObject.Find ("Ghost (1)");
		Ghosts [1] = GameObject.Find ("Ghost (2)");
		Ghosts [2] = GameObject.Find ("Ghost (3)");
		Ghosts [3] = GameObject.Find ("Ghost (4)");

		Ghost1 ();
		Ghost2 ();
		Ghost3 ();
		Ghost4 ();
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

	public void Ghost1L () {
		if (GC0 != 0) {
			GC0 -= 1;
			Ghost1 ();
		}
	}
	public void Ghost1R () {
		if (GC0 != Characters.Length - 1) {
			GC0 += 1;
			Ghost1 ();
		}
	}
	public void Ghost2L () {
		if (GC1 != 0) {
			GC1 -= 1;
			Ghost2 ();
		}
	}
	public void Ghost2R () {
		if (GC1 != Characters.Length - 1) {
			GC1 += 1;
			Ghost2 ();
		}
	}
	public void Ghost3L () {
		if (GC2 != 0) {
			GC2 -= 1;
			Ghost3 ();
		}
	}
	public void Ghost3R () {
		if (GC2 != Characters.Length - 1) {
			GC2 += 1;
			Ghost3 ();
		}
	}
	public void Ghost4L () {
		if (GC3 != 0) {
			GC3 -= 1;
			Ghost4 ();
		}
	}
	public void Ghost4R () {
		if (GC3 != Characters.Length - 1) {
			GC3 += 1;
			Ghost4 ();
		}
	}


	void Ghost1 () {
		if (Ghosts [0].transform.childCount != 0) {
			Destroy (Ghosts [0].transform.GetChild (0).gameObject);
		}
		GameObject NG = (GameObject) Instantiate (Characters [GC0], Ghosts[0].transform.position, Ghosts[0].transform.rotation);
		NG.transform.parent = Ghosts [0].transform;
	}
	void Ghost2 () {
		if (Ghosts [1].transform.childCount != 0) {
			Destroy (Ghosts [1].transform.GetChild (0).gameObject);
		}		GameObject NG = (GameObject) Instantiate (Characters [GC1], Ghosts[1].transform.position, Ghosts[1].transform.rotation);
		NG.transform.parent = Ghosts [1].transform;
	}
	void Ghost3 () {
		if (Ghosts [2].transform.childCount != 0) {
			Destroy (Ghosts [2].transform.GetChild (0).gameObject);
		}		GameObject NG = (GameObject) Instantiate (Characters [GC2], Ghosts[2].transform.position, Ghosts[2].transform.rotation);
		NG.transform.parent = Ghosts [2].transform;
	}
	void Ghost4 () {
		if (Ghosts [3].transform.childCount != 0) {
			Destroy (Ghosts [3].transform.GetChild (0).gameObject);
		}		GameObject NG = (GameObject) Instantiate (Characters [GC3], Ghosts[3].transform.position, Ghosts[3].transform.rotation);
		NG.transform.parent = Ghosts [3].transform;
	}

}
