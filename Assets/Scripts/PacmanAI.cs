using UnityEngine;
using System.Collections;

public class PacmanAI : MonoBehaviour {

	private NavMeshAgent PacAgent;
	public GameObject PacExp;
	private GameObject[] listDots;
	public Transform target;

	// Use this for initialization
	void Start () {
		listDots = GameObject.FindGameObjectsWithTag("Dot");
		PacAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!target){
			FindTarget();
		}
		else{
			PacAgent.destination = target.position;
		}
	}

	void OnCollisionEnter(Collision Col){
		if (Col.collider.tag == "Ghost") {
			Instantiate (PacExp, transform.position, Quaternion.identity);
			Destroy (gameObject);
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
