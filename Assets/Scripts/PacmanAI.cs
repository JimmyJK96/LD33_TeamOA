using UnityEngine;
using System.Collections;

public class PacmanAI : MonoBehaviour {

	private NavMeshAgent PacAgent;
	public GameObject PacExp;
	private GameObject[] listDots;
	public Transform target;
	private RaycastHit PacHit;

	private AudioSource AS;

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
	}

	void OnCollisionEnter(Collision Col){
		if (Col.collider.tag == "Ghost") {
			Instantiate (PacExp, transform.position, Quaternion.identity);
			AS.PlayOneShot (Col.gameObject.GetComponent<GhostController>().OnKillAudio);
			GetComponent<Collider>().enabled = false;
			GetComponent<Renderer>().enabled = false;
			Destroy (gameObject, 3f);
		} else if (Col.collider.tag == "Dot") {
			Destroy (Col.gameObject);
		}
	}
	void FindTarget(){
		int i = Random.Range(0,listDots.Length);
		target = listDots[i].transform;
	}

	//listWhites[] = GameObject.FindGameObjectsWithTag("White");
	//var i = Random.Range(0,listWhites.length);
	//var theObject : GameObject = listWhites[i];

}
