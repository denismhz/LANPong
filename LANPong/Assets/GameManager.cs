using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private InputField input;
    public Text sliderVal;
    public Slider difficultyS;

    private int gameTime;
    private int difficulty;

	// Use this for initialization
	void Start () {
        input = FindObjectOfType<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
        sliderVal.text = difficultyS.value.ToString();
        difficulty = (int)difficultyS.value;
        PlayerPrefs.SetInt("difficulty", difficulty);
	}

    public void OnEnter()
    {
        gameTime = int.Parse(input.text);
        PlayerPrefs.SetInt("gameTime", gameTime);
        Debug.Log(gameTime);
    }

}
