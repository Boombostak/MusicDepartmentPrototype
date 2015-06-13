using UnityEngine;
using System.Collections;

public class PlayerNetworking : MonoBehaviour {

    public int playerNumber;
    public static int numberOfPlayers;
    
    // Use this for initialization
	void Start () {
        playerNumber = numberOfPlayers;
        numberOfPlayers = GameObject.FindObjectsOfType<PlayerNetworking>().Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
