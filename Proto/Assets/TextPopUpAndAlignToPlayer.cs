using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPopUpAndAlignToPlayer : MonoBehaviour {

	public Transform playerTrans;
	public float distanceThreshold = 200f;
	public Text text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (NetworkManager.numberOfPlayers > 0) {
			playerTrans = GameObject.FindObjectOfType<PlayerInput> ().transform;
		}
		this.transform.rotation = playerTrans.rotation;
		text = this.GetComponent<Text> ();

	}
	void FixedUpdate(){
		//Debug.Log(Vector3.Distance(playerTrans.position, this.transform.position));
		if (Vector3.Distance(playerTrans.position, this.transform.position)<distanceThreshold) {
			text.enabled = true;
		} else {
			text.enabled = false;
		}
	}
}
