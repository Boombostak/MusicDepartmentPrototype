using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class ReverNodeZoneDetectorForListener : MonoBehaviour {

	//PUT THIS ON LISTENER

	public GameObject target;
	public ReverbNodeZone rnz;
	public List<GameObject> exteriorNodes;
	public List<GameObject> activeNodes;
	public ReverbControllerForListener targetController;
	// Use this for initialization
	void Start () {
		target = this.gameObject;
		targetController = target.GetComponent<ReverbControllerForListener> ();
		activeNodes = exteriorNodes;
		targetController.nodes = activeNodes.ToArray ();
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
	void OnTriigerExit(Collider other){
		activeNodes = exteriorNodes;
		targetController.nodes = activeNodes.ToArray ();
	}

}
