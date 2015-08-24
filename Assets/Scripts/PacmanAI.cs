using UnityEngine;
using System.Collections;

public class PacmanAI : MonoBehaviour {

	private NavMeshAgent PacAgent;
	public GameObject PacExp;
	private GameObject[] listDots;
	public Transform target;
	private RaycastHit PacHit;

	private AudioSource AS;

	public bool isSuper;
	public float supertime = 15f;

	// Use this for initialization
	void Start () {
		listDots = GameObject.FindGameObjectsWithTag("Dot");
		PacAgent = GetComponent<NavMeshAgent> ();
		AS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!target){
			FindTarget();
		}
		else{
			PacAgent.destination = target.position;
		}

		if (Physics.Raycast (transform.position, transform.forward, out PacHit, 3f)) {
			if (PacHit.transform.tag == "Ghost"){
				Debug.Log ("Fuck Fuck Fuck!");
				FindTarget();
			}
		}

		if (isSuper == true) {
			GetComponent<Light> ().enabled = true;
		} else {
			GetComponent<Light> ().enabled = false;
		}
	}

	void OnCollisionEnter(Collision Col){
		if (Col.collider.tag == "Ghost") {
			if (isSuper == true){
				Destroy (Col.gameObject);
			}else{
				Instantiate (PacExp, transform.position, Quaternion.identity);
				AS.PlayOneShot (Col.gameObject.GetComponentInChildren<GhostInfo>().OnKillAudio);
				GetComponent<Collider>().enabled = false;
				GetComponent<Renderer>().enabled = false;
				Destroy (gameObject, 3f);
			}
		
		} else if (Col.collider.tag == "Dot") {
			if (Col.transform.parent.name == "SuperDots"){
				isSuper = true;
				Invoke ("EndSuper", supertime);
		}
		Destroy (Col.gameObject);
		}
	}
	void FindTarget(){
		int i = Random.Range(0,listDots.Length);
		target = listDots[i].transform;
	}

	void EndSuper () {
		isSuper = false;
	}

	//listWhites[] = GameObject.FindGameObjectsWithTag("White");
	//var i = Random.Range(0,listWhites.length);
	//var theObject : GameObject = listWhites[i];

}
