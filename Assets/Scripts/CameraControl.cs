using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float Speed = 0.1f;
	private Vector3 MoveTo;

	public GameObject ClickEffects;

	public GameObject ActiveGhost;
	public GameObject[] Ghosts;
	private RaycastHit Hit;

	public AudioClip GameMusic;
	public AudioClip SoundEffect;

	private AudioSource Audio;
	private GhostController AG;
	private GhostInfo GI;



	// Use this for initialization
	void Awake () {
	
		MoveTo = transform.position;
		ActiveGhost = Ghosts [0];
		Audio = GetComponent<AudioSource> ();

	}

	void Update () {

		if (Input.GetButtonDown ("1") && Ghosts[0]) {
			ActiveGhost = Ghosts[0];
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
		} else if (Input.GetButtonDown ("2") && Ghosts[1]) {
			ActiveGhost = Ghosts[1];
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
		} else if (Input.GetButtonDown ("3") && Ghosts[2]) {
			ActiveGhost = Ghosts[2];
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
		} else if (Input.GetButtonDown ("4") && Ghosts[3]) {
			ActiveGhost = Ghosts[3];
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
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
		//Camera move
		MoveTo += new Vector3 (Input.GetAxis ("Horizontal")*Speed, -Input.GetAxis ("Mouse ScrollWheel")*10f, Input.GetAxis ("Vertical")*Speed);
		MoveTo.x = Mathf.Clamp (MoveTo.x, -20f, 20f);
		MoveTo.z = Mathf.Clamp (MoveTo.z, -20f, 20f);
		MoveTo.y = Mathf.Clamp (MoveTo.y, 5f, 30f);
		transform.position = Vector3.Lerp (transform.position, MoveTo, Speed);
	}

	void PlaySoundEffect() {
		GI = AG.gameObject.GetComponentInChildren<GhostInfo> ();
		SoundEffect = GI.OnActiveAudio[Random.Range (0, 3)];
		Audio.PlayOneShot (SoundEffect);
	}

	void TagGhost () {
		ActiveGhost = Hit.transform.gameObject;
		AG = ActiveGhost.GetComponent<GhostController>();
//		GI = AG.gameObject.GetComponentInChildren<GhostInfo> ();
		PlaySoundEffect();
	}
	void TagFloor () {
		if (ActiveGhost != null) {
			ActiveGhost.GetComponent<GhostController>().GMoveTo = Hit.point;
			GameObject CE = (GameObject) Instantiate (ClickEffects, Hit.point, Quaternion.identity);
			Destroy (CE, 4f);
		}
	}

}
