using UnityEngine;
using System.Collections;

public class ReverbNodeZone : MonoBehaviour {

	public Collider collider;
	public GameObject[] nodeArray;
	public GameObject player;
	public Collision testToHit;
	public Rigidbody rigidBody;
	public float checkDistance;
	public RaycastHit hit;

	//USE ONTRIGGERSTAY!!! Test if the player is staying in the trigger and adjust accordingly.

	//for loop if the node is inside the collider it goes into the array of nodes associated with this collider. 
	//If the player is inside the collider, the colliders node array becomes the players node array.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
