using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PongBall : MonoBehaviour {
    Rigidbody rigidBody;
    public float speed = 20f;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        Invoke("StartBall", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        rigidBody.AddForce(-collision.transform.position * speed);
        Debug.Log("addforce");
    }

    void StartBall()
    {
        rigidBody.velocity = Vector3.up * 20;
    }
}
