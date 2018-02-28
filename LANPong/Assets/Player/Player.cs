using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    public float speed = 30;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (!isClient)
        {
            return;
        }
        float input = CrossPlatformInputManager.GetAxis("Vertical");
        //TEST moving with transform
        rigidBody.velocity = new Vector2(0, input * speed);
    }
}
