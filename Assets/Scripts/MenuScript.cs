using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public bool credits = false;
	// Use this for initialization
	void Start () {

		if (credits) {
			Application.LoadLevel (4);
		} else {
			Application.LoadLevel (2);
		}
	}

}
