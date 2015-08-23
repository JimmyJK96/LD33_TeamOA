using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	public Transform bounceHeight;
	public Transform bounceLand;
	public float bounceTime;
	public bool goingUp = false;
	public bool goingDown = false;

	void Start() {

		StartCoroutine(BounceModel());
	}

	void Update(){
		float step = 1 * Time.deltaTime;
		if (goingUp) {
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, bounceHeight.localPosition, step);
		}
		if(goingDown){
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, bounceLand.localPosition, step);
		}

	}

	IEnumerator BounceModel() {
		goingUp = true;
		yield return new WaitForSeconds(bounceTime);
		goingUp = false;
		goingDown = true;
		yield return new WaitForSeconds(bounceTime);
		goingDown = false;
		StartCoroutine(BounceModel());
	}

}
