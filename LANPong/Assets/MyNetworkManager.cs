using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MyNetworkManager : NetworkManager {

	// Use this for initialization
	void Start () {
        StartServer();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(NetworkServer.connections.Count);
    }

    public void ConnectClient()
    {
        StartClient();
    }
}
