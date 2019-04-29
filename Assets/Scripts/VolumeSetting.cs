using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;


public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private GameObject MusicSlider;
    public float MusicVal;
    private Text MusicText;

    // Use this for initialization
    void Start()
    {
        
        MusicChange(PlayerPrefs.GetFloat("Music"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MusicChange(float Value)
    {
        MusicVal = Value;
       // MusicText.text("Music Volume: " + Mathf.RoundToInt(MusicVal) + "%");

        MusicSlider.GetComponent<Slider>().value = MusicVal;
    }

}
