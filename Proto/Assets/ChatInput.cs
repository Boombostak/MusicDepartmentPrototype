using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatInput : MonoBehaviour {

	public Canvas chatCanvas;
	public bool chatMode = false;

	// Use this for initialization
	void Start () {
		chatCanvas = this.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Chat")) {
			chatCanvas.enabled = !chatCanvas.enabled;
			chatMode = !chatMode;
		}

	}
}
