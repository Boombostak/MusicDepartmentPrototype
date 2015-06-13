using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    //This script handles player joining and instantiating over network.

    public Canvas canvas;
    public Text connectionText;
    [SerializeField] Camera lobbyCam;
    public GameObject[] spawnpoints;
    public int playerCount;

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");
        connectionText = canvas.GetComponentInChildren<Text>();
    }

    void OnJoinedLobby()
    {
        RoomOptions ro = new RoomOptions() { isVisible = true, maxPlayers = 10 }; 
        PhotonNetwork.JoinOrCreateRoom("room1", ro, TypedLobby.Default);
        Debug.Log("joined room");
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join room!");
        PhotonNetwork.CreateRoom("room1", true, true, 10);
    }

    void OnJoinedRoom()
    {
        playerCount = PlayerNetworking.numberOfPlayers;
        PhotonNetwork.Instantiate("player", spawnpoints[playerCount].transform.position, Quaternion.identity, 0);
        lobbyCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }
}