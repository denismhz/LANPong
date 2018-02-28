using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PongBall : MonoBehaviour {
    Rigidbody rigidBody;
    public float speed = 1f;
    public float side = 100f;

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
        Vector2 direction = new Vector2(side * CrossPlatformInputManager.GetAxis("Horizontal"), -collision.transform.position.y * speed);
        
        rigidBody.AddForce(direction);
        Debug.Log(direction);
    }

    void StartBall()
    {
        rigidBody.velocity = Vector3.up * 10;
    }
}
