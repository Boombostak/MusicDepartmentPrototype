using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PlayerInput : MonoBehaviour {

    public CharacterController character_controller;
    public float move_speed;
    public float rotate_speed;
    public AudioClip beepclip;
    public AudioSource source;
    public AudioClip micclip;

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * move_speed;
        Vector3 sides2side = Input.GetAxis("Horizontal") * transform.TransformDirection(Vector3.right) * move_speed;
        character_controller.Move(forward + sides2side);
        character_controller.SimpleMove(Physics.gravity);

        if (Input.GetButtonDown("Fire1"))
        {
            source.clip = beepclip;
            source.Play();
        }

        if (Input.GetButtonDown("Jump"))
        {
            micclip = Microphone.Start(MicTest.device,false,10,44100);
        }

        if (Input.GetButtonUp("Jump"))
        {
            Microphone.End(MicTest.device);
            source.clip = micclip;
            source.Play();
        }
	}


}
