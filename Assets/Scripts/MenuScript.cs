using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void ChangeScene (int SceneToChange){
		Application.LoadLevel (SceneToChange);
	}
	public void KillProgram () {
		Application.Quit();
	}

}
