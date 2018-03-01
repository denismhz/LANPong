using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    public float speed = 30f;
    public Text scoreP1;
    public Text scoreP2;
    public Text time;

    private AudioSource audioSource;
    private int gameTime;
    private Rigidbody2D rigidBody;
    private int score1 = 0;
    private int score2 = 0;
    private float lastUpdate;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        speed *= PlayerPrefs.GetInt("difficulty");
        rigidBody.velocity = Vector2.right * speed;
        audioSource = GetComponent<AudioSource>();
        gameTime = PlayerPrefs.GetInt("gameTime");
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.gameObject.tag == "Wall"))
        {
            if (collision.gameObject.name == "Player1")
            {
                float x = HitObject(transform.position, collision.transform.position, collision.collider.bounds.size.y);
                Vector2 s = new Vector2(1, x);
                rigidBody.velocity = s * speed;
            } else if (collision.gameObject.name == "Player2")
            {
                float y = HitObject(transform.position, collision.transform.position, collision.collider.bounds.size.y);
                Vector2 d = new Vector2(-1, y);
                rigidBody.velocity = d * speed;
            }
        }
        if(collision.gameObject.name == "LeftWall")
        {
            score2++;
            scoreP2.text = score2.ToString();
            PlayerPrefs.SetInt("scorePlayer2", score2);
        } else if(collision.gameObject.name == "RightWall")
        {
            score1++;
            scoreP1.text = score1.ToString();
            PlayerPrefs.SetInt("scorePlayer1", score1);
        }

        audioSource.Play();
    }

    float HitObject(Vector2 ballPos, Vector2 playerPos, float playerHeight)
    {
        return (ballPos.y - playerPos.y) / playerHeight;
    }

    // Update is called once per frame
    void Update () {
        UpdateGameTime();
        time.text = gameTime.ToString();
	}

    void UpdateGameTime()
    {
        if(Time.time - lastUpdate >= 1f)
        {
            gameTime--;
            lastUpdate = Time.time;
            EndGame();
        }
    }

    void EndGame()
    {
        if(gameTime <= 0)
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("gameTime", 0);
            
        }
    }
}
