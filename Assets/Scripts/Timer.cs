using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
     float startTimer;
     float t;
     public int minutes;
     public float seconds;
    private bool finish = false;
    Collect finishing;
    
	// Use this for initialization
	void Start () {
        startTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (finish)
            return;

        t = Time.time - startTimer;

        minutes = ((int)t / 60);
        seconds = (t % 60);
	}
    public void Finished()
    {
        finish = true;
    }
}
