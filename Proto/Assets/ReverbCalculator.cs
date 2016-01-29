using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ReverbCalculator : MonoBehaviour {

	public AudioMixer mixer;
	public AudioMixerSnapshot[] snapshots;
	public GameObject[] nodes;
	public float[] closenesses;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < nodes.Length; i++) {
			closenesses[i] = 1/
				Vector3.Distance(nodes[i].transform.position, 
				                 GameObject.FindGameObjectWithTag("Player").transform.position);
		}
		BlendSnapshots ();
	}

	public void BlendSnapshots()
	{
		mixer.TransitionToSnapshots (snapshots, closenesses, 0.005f);
	}
}