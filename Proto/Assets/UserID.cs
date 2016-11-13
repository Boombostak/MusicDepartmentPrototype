using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserID : MonoBehaviour {

	public string username;
	public TextPopUpAndAlignToPlayer popup;
	public Text name;
	public InputField nameInputField;

	// Use this for initialization
	void Start () {
		nameInputField = GameObject.Find ("NameInputField").GetComponent<InputField> ();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		if (nameInputField.transform.parent.GetComponent<Canvas>().enabled == false) {
			name.text = nameInputField.text;
			username = nameInputField.text;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
