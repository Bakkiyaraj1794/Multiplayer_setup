using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefs;

    public string Playername;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void ConnectNetwork()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        Debug.Log("Connected to master");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined to random room");
        PhotonNetwork.Instantiate(PlayerPrefs.name, Vector3.zero, Quaternion.identity);
    }
  
}
