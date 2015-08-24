using UnityEngine;
using System.Collections;

public class RandomSong : MonoBehaviour {

	public AudioClip[] SongList;
	private AudioSource AudioS;

	// Use this for initialization
	void Awake () {
	
		AudioS = GetComponent<AudioSource> ();
		AudioS.PlayOneShot (SongList[Random.Range (0, SongList.Length)]);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
