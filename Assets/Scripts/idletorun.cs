using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idletorun : MonoBehaviour {

    Animator anim;
	void Start ()
    {

        anim = GetComponent<Animator>();
		
	}
	
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.W)) anim.SetTrigger("idletorun");
		
	}
}
