using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour {
    public int nMatchBox;
    public int nGunPowder;
    public Text MBox;
    public Text GPowder;
    public Text nextLevel;

	// Use this for initialization
	void Start () {
        nMatchBox = 0;
        nGunPowder = 0;

        nextLevel.text = "";
        MBox.text = nMatchBox.ToString() + "/ 1";
        GPowder.text = nGunPowder.ToString() + "/ 10";
    }
    
    //player collects the items and the count goes up by one 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MatchBox"))
        {
            other.gameObject.SetActive(false);
            nMatchBox += 1;
            MBox.text = nMatchBox.ToString() + "/ 1";
        }
        if(other.gameObject.CompareTag("Powder"))
        {
            other.gameObject.SetActive(false);
            nGunPowder += 1;
            GPowder.text = nGunPowder.ToString() + "/ 10";
        }
        
        if(nMatchBox == 1 && nGunPowder==10 && other.gameObject.CompareTag("Win"))
        {
            nextLevel.text = "You have beat Level 1";
        }
    }

}
