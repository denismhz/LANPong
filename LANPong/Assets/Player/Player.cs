using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    [Tooltip("Set at least to 3")]
    public float speed = 3f;

    private MyNetworkManager networkManager;

	// Use this for initialization
	void Start () {
        networkManager = FindObjectOfType<MyNetworkManager>();
        //transform.position = networkManager.GetStartPosition().position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        float xPos = CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(new Vector2(xPos, 0));
        //Debug.Log("Transform pos: " + transform.position + " xPos: " + xPos);
	}
}
