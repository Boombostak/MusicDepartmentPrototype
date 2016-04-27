﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class ReverbNodeZoneDetector : MonoBehaviour {

	//PUT THIS ON THINGS THAT MAKE SOUNDS

	public GameObject target;
	public ReverbNodeZone rnz;
	public List<GameObject> activeNodes;
	public ReverbController targetController;
	// Use this for initialization
	void Start () {
		target = this.gameObject;
		targetController = target.GetComponent<ReverbController> ();
	}
	
	void OnTriggerStay(Collider other){
		Debug.Log ("triggerstay");
		rnz = other.gameObject.GetComponent<ReverbNodeZone> ();
		//activeNodes = new GameObject[rnz.nodeList.Count];
		activeNodes = rnz.nodeList;
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("triggerenter");
		rnz = other.gameObject.GetComponent<ReverbNodeZone> ();
		//activeNodes = new GameObject[rnz.nodeList.Count];
		activeNodes = rnz.nodeList;
		targetController.nodes = activeNodes.ToArray();
	}
}
