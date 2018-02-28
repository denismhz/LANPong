using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    private MusicManager instance = null;
    private AudioSource audioSource;

    public Slider slider;

    private void Start()
    {
        
        if (instance = null)
        {
            instance = this;
        } else if(instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        slider.value = PlayerPrefs.GetFloat("volume");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        PlayerPrefs.SetFloat("volume", slider.value);
        audioSource.volume = slider.value;
    }
}
