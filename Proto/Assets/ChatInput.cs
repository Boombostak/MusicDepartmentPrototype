using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using Photon;

public class ChatInput : MonoBehaviour {

	public Canvas chatCanvas;
	public bool chatMode = false;
	public Chat chat;

	// Use this for initialization
	void Start () {
		chatCanvas = this.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Chat")) {
			chatCanvas.enabled = !chatCanvas.enabled;
			chat.enabled = !chat.enabled;
			chatMode = !chatMode;
		}

	}
}
