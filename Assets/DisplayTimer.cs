using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour {
    public Text Timer;
    private int minutes;
    private float seconds;
	// Use this for initialization
	void Start () {
        minutes = PlayerPrefs.GetInt("Minutes");
        seconds = PlayerPrefs.GetFloat("Seconds");

        Timer.text = minutes.ToString() + ":" + seconds.ToString("f2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
