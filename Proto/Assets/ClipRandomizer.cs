using UnityEngine;
using System.Collections;

public class ClipRandomizer : MonoBehaviour {

	public AudioClip[] clips;
	public AudioSource audiosource;
	public AudioClip clip;
	public TimeControl timecontrol;

	public void PlayAClip(){
		audiosource.clip = clips [Random.Range (0, clips.Length - 1)];
		audiosource.Play();
	
	}

	public void PlayAClipWithRandomDelay(){
		float randomFloat;
		randomFloat = Random.Range (0f, 60f * 1/timecontrol.timeMultiplier);
		audiosource.clip = clips [Random.Range (0, clips.Length - 1)];
		audiosource.PlayDelayed (randomFloat);
		Debug.Log ("Playback delayed by" + randomFloat);
	}

	// Use this for initialization
	void Start () {
		timecontrol = GameObject.FindObjectOfType<TimeControl> ().GetComponent<TimeControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
