using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour {
    public float speed = 30f;

    private AudioSource audioSource;

    private Rigidbody2D rigidBody;
    private int score1 = 0;
    private int score2 = 0;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        speed *= PlayerPrefs.GetInt("difficulty");
        rigidBody.velocity = Vector2.right * speed;
        audioSource = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.gameObject.tag == "Wall"))
        {
            if (!isClient)
            {
                float x = HitObject(transform.position, collision.transform.position, collision.collider.bounds.size.y);
                Vector2 s = new Vector2(1, x);
                rigidBody.velocity = s * speed;
            }
            else
            {
                float y = HitObject(transform.position, collision.transform.position, collision.collider.bounds.size.y);
                Vector2 d = new Vector2(-1, y);
                rigidBody.velocity = d * speed;
            }
        }
        if(collision.gameObject.name == "LeftWall")
        {
            score2++;
        } else if(collision.gameObject.name == "RightWall")
        {
            score1++;
        }

        audioSource.Play();
    }

    float HitObject(Vector2 ballPos, Vector2 playerPos, float playerHeight)
    {
        return (ballPos.y - playerPos.y) / playerHeight;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
