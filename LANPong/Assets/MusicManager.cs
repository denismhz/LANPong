using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    private static MusicManager instance;
    private AudioSource audioSource;

    private Slider volumeSlider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
            Debug.Log("second mp destroyed");
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        volumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update () {
        if (volumeSlider)
        {
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
            audioSource.volume = volumeSlider.value;
        }
    }
}
