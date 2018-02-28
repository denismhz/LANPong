using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

	// Use this for initialization
	void Start () {
        StartHost();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("gameTime") <= 0)
        {

            StopServer();
            StopHost();
        }
	}
}
