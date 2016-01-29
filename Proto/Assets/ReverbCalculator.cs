﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ReverbCalculator : MonoBehaviour {

    public GameObject target;
    public AudioMixer mixer;
	public AudioMixerSnapshot[] snapshots;
	public GameObject[] nodes;
	public float[] closenesses;

	// Use this for initialization
	void Start () {
        target = this.gameObject;
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {

        //update positions (should this be a coroutine?)
        for (int i = 0; i < nodes.Length; i++) {
			closenesses[i] = 1/
				Vector3.Distance(nodes[i].transform.position, 
				                 target.transform.position);
		}
		BlendSnapshots ();
	}

	public void BlendSnapshots()
	{
		mixer.TransitionToSnapshots (snapshots, closenesses, 0.005f);
	}

    public void SetUp()
    {
        for (int i = 0; i < GameObject.Find("reverbManager").transform.FindChild("nodesGO").childCount; i++)
        {
            nodes[i] = GameObject.Find("reverbManager").transform.FindChild("nodesGO").transform.GetChild(i).gameObject;
        }
    }
}