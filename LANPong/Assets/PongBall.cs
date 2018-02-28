using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PongBall : MonoBehaviour {
    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //direction = collision.transform.position;
        //rigidBody.velocity = direction + bounceVelocity;
        rigidBody.velocity = new Vector3(1f * CrossPlatformInputManager.GetAxis("Horizontal") , 20f, 0f);
    }
}
