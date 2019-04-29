using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTexts : MonoBehaviour {

     public GameObject objective;
    public GameObject controls;

	// Use this for initialization
	void Start () {
        Destroy(objective, 3);
        Destroy(controls, 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
