using UnityEngine;
using System.Collections;

public class ClipRandomizer : MonoBehaviour {

	public AudioClip[] clips;
	public AudioSource audiosource;

	public void PlayAClip(){
		audiosource.PlayOneShot (clips [Random.Range (0, clips.Length - 1)]);
	
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
