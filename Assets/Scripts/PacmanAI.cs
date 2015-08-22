using UnityEngine;
using System.Collections;

public class PacmanAI : MonoBehaviour {

	private NavMeshAgent PacAgent;


	// Use this for initialization
	void Start () {
		PacAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
//		Agent.destination = ;

	}

	void OnCollisionEnter(Collision Col){
		if (Col.collider.tag == "Ghost") {
			Destroy (gameObject);
		}
	}

}
