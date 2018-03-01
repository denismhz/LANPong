using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEnd : MonoBehaviour {

    public Text score1;
    public Text score2;

    // Use this for initialization
    void Start () {
        score1.text = "LeftPlayerScore:\n\n" + PlayerPrefs.GetInt("scorePlayer1").ToString();
        score2.text = "RightPlayerScore:\n\n" + PlayerPrefs.GetInt("scorePlayer2").ToString();
        PlayerPrefs.SetInt("scorePlayer1", 0);
        PlayerPrefs.SetInt("scorePlayer2", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
