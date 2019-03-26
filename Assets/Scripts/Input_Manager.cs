using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Manager : MonoBehaviour {
    public float JSDeadzone = 0.1f;
    public float JSSensitivity = 2.0f;
    public float mouseSensitivity = 2.0f;


   // Player_Controller player;
	// Use this for initialization
	void Start () {

        //player = GameObject.FindObjectOfType<Player_Controller>();
	}

    // Update is called once per frame
    void Update()
    {
        Movement();
        CamRotation();
    }
    private void Movement()
    {
        float mSideway = Input.GetAxis("Horizontal");
        float mForward = Input.GetAxis("Vertical");

        
        if (mForward< JSDeadzone && mForward > -JSDeadzone)
        {
            mForward = 0;
        }
        if (mSideway < JSDeadzone && mSideway > -JSDeadzone)
        {
            mSideway = 0;
        }
        Vector3 direction = new Vector3(mSideway, 0.0f, mForward);
       
        //player.Movement(direction);
    }
    private void CamRotation()
    {
        float XRotate = Input.GetAxis("Mouse X")*mouseSensitivity;
        float YRotate = Input.GetAxis("Mouse Y")*mouseSensitivity;

        if(Input.GetAxis("RJoyStickX") > JSDeadzone || Input.GetAxis("RJoyStickX") < -JSDeadzone)
        {
            XRotate = Input.GetAxis("RJoyStickX") * JSSensitivity;
        }

        if (Input.GetAxis("RJoyStickY") > JSDeadzone || Input.GetAxis("RJoyStickY") < -JSDeadzone)
        {
            YRotate = Input.GetAxis("RJoyStickY") * JSSensitivity;
        }

        Vector3 rotateCam = new Vector3(0.0f, XRotate, YRotate);
        //Debug.Log(rotateCam);
        if (rotateCam != Vector3.zero)
        {
            //player.RotationCamera(rotateCam);
        }

    }
}
