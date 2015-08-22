﻿using UnityEngine;
using System.Collections;

public class TimedSceneChange : MonoBehaviour {

	public int LevelToLoad = 1;
	public float WaitTime = 3f;

	void Awake () {
		Invoke ("ChangeScene", WaitTime);
	}
	
	void ChangeScene () {
		Application.LoadLevel (1);
	}
}
