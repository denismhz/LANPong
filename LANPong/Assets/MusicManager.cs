using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    private MusicManager instance = null;
    private AudioSource audioSource;

    private Slider volumeSlider;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self destructing");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            volumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
           
            
        }
        
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
