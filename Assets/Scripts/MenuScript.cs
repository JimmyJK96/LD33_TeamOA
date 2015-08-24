using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void ChangeScene (int SceneToChange){
		Application.LoadLevel (SceneToChange);
	}

}
