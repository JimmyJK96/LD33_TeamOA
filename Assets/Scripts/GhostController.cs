using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public Vector3 GMoveTo;
	private NavMeshAgent Agent;

	// Use this for initialization
	void Awake () {
		GMoveTo = transform.position;
		Agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		Agent.destination = GMoveTo;

	}
}
