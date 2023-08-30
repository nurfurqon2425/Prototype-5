using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;
    private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        backgroundMusic = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetVolume()
    {
        backgroundMusic.volume = volumeSlider.value;
    }
}
