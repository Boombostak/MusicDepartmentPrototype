using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class ReverNodeZoneDetectorForListener : MonoBehaviour {

	//PUT THIS ON LISTENER

	public GameObject target;
	public ReverbNodeZone rnz;
	public List<GameObject> activeNodes;
	public ReverbControllerForListener targetController;
	public List<ReverbNodeZone> zonesCurrentlyInsideOf;
	// Use this for initialization
	void Start () {
		target = this.gameObject;
		targetController = target.GetComponent<ReverbControllerForListener> ();
		targetController.nodes = activeNodes.ToArray ();
	}

	/*void OnTriggerStay(Collider other){
		Debug.Log ("triggerstay");
		rnz = other.gameObject.GetComponent<ReverbNodeZone> ();
		//activeNodes = new GameObject[rnz.nodeList.Count];
		activeNodes = rnz.nodeList;
	}*/
	void OnTriggerEnter(Collider other){
		
		rnz = other.gameObject.GetComponent<ReverbNodeZone> ();
		zonesCurrentlyInsideOf.Add (rnz);
		if (rnz.isExclusive) {
			activeNodes = rnz.nodeList;
		} 
		else {
			activeNodes.AddRange(rnz.nodeList.Except(activeNodes));
			foreach (var node in rnz.associatedNodes) {
				activeNodes.Remove (node);
			}
		}
		if (rnz.linkedZones!=null) {
			foreach (var zone in rnz.linkedZones) {
				activeNodes.AddRange(zone.nodeList.Except(activeNodes));
				foreach (var node in rnz.associatedNodes) {
					activeNodes.Remove (node);
				}
			}
		}
		targetController.nodes = activeNodes.ToArray();
	}


	void OnTriggerExit(Collider other){
		rnz = other.gameObject.GetComponent<ReverbNodeZone> ();
		zonesCurrentlyInsideOf.Remove (rnz);
		if (rnz.linkedZones!=null) {
			foreach (var zone in zonesCurrentlyInsideOf) {
				//NEED TO ACCOUNT FOR LINKED ZONES WHEN EXITING!
			}
		}
		foreach (var node in rnz.nodeList) {
			activeNodes.Remove (node);
		}
		targetController.nodes = activeNodes.ToArray();
		if (activeNodes.Count ==0) {
			activeNodes.AddRange( rnz.associatedNodes);
		}
		this.transform.position+= Vector3.zero; //retrigger overlapping trigger colliders?
	}

}
