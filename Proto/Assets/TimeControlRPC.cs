using UnityEngine;
using System.Collections;
using Photon;

public class TimeControlRPC : MonoBehaviour {

	public float timeMultiplier;
	public GameObject superUser;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < max; i++) {
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[PunRPC]
	public void SyncTime(){}
}
