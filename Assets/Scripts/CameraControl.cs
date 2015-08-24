using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float Speed = 0.1f;
	private Vector3 MoveTo;

	public GameObject ActiveGhost;
	public GameObject[] Ghosts;
	private RaycastHit Hit;

	public AudioClip GameMusic;
	public AudioClip SoundEffect;

	private AudioSource Audio;
	private GhostController AG;

	// Use this for initialization
	void Awake () {
	
		MoveTo = transform.position;
		ActiveGhost = Ghosts [1];
		Audio = GetComponent<AudioSource> ();

	}

	void Update () {

		if (Input.GetButtonDown ("1")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[0];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
		} else if (Input.GetButtonDown ("2")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[1];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
		} else if (Input.GetButtonDown ("3")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[2];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
			AG = ActiveGhost.GetComponent<GhostController>();
			PlaySoundEffect();
		} else if (Input.GetButtonDown ("4")) {
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
			ActiveGhost = Ghosts[3];
			ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
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
		SoundEffect = AG.OnActiveAudio[Random.Range (0, 3)];
		Audio.PlayOneShot (SoundEffect);
	}

	void TagGhost () {
		ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (false);
		ActiveGhost = Hit.transform.gameObject;
		ActiveGhost.transform.Find ("ActiveParticles").gameObject.SetActive (true);
		AG = ActiveGhost.GetComponent<GhostController>();
		PlaySoundEffect();
	}
	void TagFloor () {
		if (ActiveGhost != null) {
			ActiveGhost.GetComponent<GhostController>().GMoveTo = Hit.point;
		}
	}

}
