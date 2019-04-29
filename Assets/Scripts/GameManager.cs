using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {
    public AudioMixer audioMixer;
    public static float music;
    public static float sfx;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        //music = PlayerPrefs.GetFloat("MusicVolume");
        //Debug.Log(music);
    }
   
}
