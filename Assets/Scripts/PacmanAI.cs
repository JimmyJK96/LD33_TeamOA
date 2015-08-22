using UnityEngine;
using System.Collections;

public class PacmanAI : MonoBehaviour {

	private NavMeshAgent PacAgent;
	public GameObject PacExp;

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
			Instantiate (PacExp, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

}
