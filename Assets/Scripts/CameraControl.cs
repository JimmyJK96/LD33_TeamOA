using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float Speed = 0.1f;
	private Vector3 MoveTo;

	public GameObject ActiveGhost;
	public GameObject[] Ghosts;
	private RaycastHit Hit;

	// Use this for initialization
	void Awake () {
	
		MoveTo = transform.position;
		ActiveGhost = Ghosts [1];

	}

	void Update () {

		if (Input.GetButton ("1")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[0];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
		} else if (Input.GetButton ("2")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[1];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
		} else if (Input.GetButton ("3")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[2];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
		} else if (Input.GetButton ("4")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[3];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
		}

		if (Input.GetButtonDown ("Action1")) {
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out Hit, 1000f)) {
				Debug.Log (Hit.transform.tag);
				if (Hit.transform.tag == "Ghost"){
					TagGhost ();
				}else if (Hit.transform.tag == "Floor"){
					TagFloor ();
				}
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		MoveTo += new Vector3 (Input.GetAxis ("Horizontal")*0.1f, -Input.GetAxis ("Mouse ScrollWheel")*10f, Input.GetAxis ("Vertical")*0.1f);
		transform.position = Vector3.Lerp (transform.position, MoveTo, Speed);



	}

	void TagGhost () {
		ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
		ActiveGhost = Hit.transform.gameObject;
		ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
	}
	void TagFloor () {
		if (ActiveGhost != null) {
			ActiveGhost.GetComponent<GhostController>().GMoveTo = Hit.point;
		}
	}

}
