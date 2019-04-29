using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

    public GameObject elevatorPanel;

    enum EleStates {goUP, goDown, PauseState};
    EleStates states;

    public Transform top;
    public Transform bottom;

    public float smooth;

    Vector3 newPos;

    bool hasRider;
    public GameObject otherObject;
    Animator otherAnim;
    void Awake()
    {
        otherAnim = otherObject.GetComponent<Animator>();
    }

    void Start()
    {
        elevatorPanel.SetActive (false);
        states = EleStates.PauseState;
    }

	

	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.U) && hasRider || Input.GetKey("joystick button 3") && hasRider)
        {
            states = EleStates.goUP;
            otherAnim.SetBool("gliding", false);
            otherAnim.SetBool("running", false);
            otherAnim.SetBool("Idle", false);
            otherAnim.SetBool("Jumping", false);
            otherAnim.SetBool("Climbing", true);
            otherAnim.SetInteger("condition", 4);
        }
        if (Input.GetKeyDown(KeyCode.J) && hasRider ||Input.GetKey("joystick button 2") && hasRider)
        {
            states = EleStates.goDown;
            otherAnim.SetBool("gliding", false);
            otherAnim.SetBool("running", false);
            otherAnim.SetBool("Idle", false);
            otherAnim.SetBool("Jumping", false);
            otherAnim.SetBool("Climbing", true);
            otherAnim.SetInteger("condition", 4);
        }
        if (Input.GetKeyUp(KeyCode.U) && hasRider|| Input.GetKey("joystick button 3") && hasRider)
        {
            states = EleStates.goUP;
            otherAnim.SetBool("gliding", false);
            otherAnim.SetBool("running", false);
            otherAnim.SetBool("Idle", true);
            otherAnim.SetBool("Jumping", false);
            otherAnim.SetBool("Climbing", false);
            otherAnim.SetInteger("condition", 0);
        }
        if (Input.GetKeyUp(KeyCode.J) && hasRider || Input.GetKey("joystick button 2") && hasRider)
        {
            states = EleStates.goDown;
            otherAnim.SetBool("gliding", false);
            otherAnim.SetBool("running", false);
            otherAnim.SetBool("Idle", true);
            otherAnim.SetBool("Jumping", false);
            otherAnim.SetBool("Climbing", false);
            otherAnim.SetInteger("condition", 0);
        }

        FMS ();

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            elevatorPanel.SetActive(true);
            coll.transform.parent = gameObject.transform;
            hasRider = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            elevatorPanel.SetActive(false);
            coll.transform.parent = null;
            hasRider = false;

        }
    }

    void FMS()
    {
        if(states == EleStates.goDown)
        {
            newPos = bottom.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }
        if (states == EleStates.goUP)
        {
            newPos = top.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }
        if (states == EleStates.PauseState)
        {

     
     
        }
    }
}
