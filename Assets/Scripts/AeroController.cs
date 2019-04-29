using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeroController : MonoBehaviour
{
    float speed = 3;
    float rotSpeed = 115;
    float rot = 0f;
    float gravity = 13;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator>();
    }

   void Update()
    {
        Movement();
    }

    void Movement()
    {
        float vert = Input.GetAxis("Vertical");
        bool air;
        if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, vert);
            moveDir = moveDir * speed;
            moveDir = transform.TransformDirection(moveDir);
            if (vert == 1)
            {
                anim.SetBool("gliding", false);
                anim.SetBool("running", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Climbing", false);
                anim.SetInteger("condition", 1);
            }
            else
            {
                anim.SetBool("gliding", false);
                anim.SetBool("running", false);
                anim.SetBool("Idle", true);
                anim.SetBool("Jumping", false);
                anim.SetBool("Climbing", false);
                anim.SetInteger("condition", 0);
            }
            if (Input.GetKey(KeyCode.F) || Input.GetKey("joystick button 0"))
            {
                anim.SetBool("gliding", true);
                anim.SetBool("running", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Climbing", false);
                anim.SetInteger("condition", 2);
                air = true;
                moveDir = new Vector3(0, 4, 5);
                moveDir = moveDir * speed;
                moveDir = transform.TransformDirection(moveDir);

            }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 1"))
            {
                anim.SetBool("gliding", false);
                anim.SetBool("running", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Jumping", true);
                anim.SetBool("Climbing", false);
                anim.SetInteger("condition", 3);
                air = true;
                moveDir = new Vector3(0, 3, 1);
                moveDir = moveDir * speed;
                moveDir = transform.TransformDirection(moveDir);

            }
            else if (!controller.isGrounded)
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    anim.SetBool("gliding", false);
                    anim.SetBool("running", false);
                    anim.SetBool("Idle", true);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Climbing", false);
                    anim.SetInteger("condition", 0);
                    air = false;
                    moveDir = new Vector3(0, 0, 0);
                }
            }

            /* if (Input.GetKey(KeyCode.W))
             {
                 anim.SetBool("gliding", true);
                 anim.SetInteger("condition", 1);
                 moveDir = new Vector3(0, 0, vert);
                 moveDir = moveDir * speed;
                 moveDir = transform.TransformDirection(moveDir);
             }
             if (Input.GetKeyUp(KeyCode.W))
             {
                 anim.SetBool("gliding", false);
                 anim.SetInteger("condition", 0);
                 moveDir = new Vector3(0, 0, 0);
             }*/

        }

       /* if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.F) || Input.GetKey("joystick button 0"))
            {
                anim.SetBool("gliding", true);
                anim.SetBool("running", false);
                anim.SetBool("Idle", false);
                anim.SetInteger("condition", 2);
                air = true;
                moveDir = new Vector3(0, 2, 2);
                moveDir = moveDir * speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            else if (!controller.isGrounded)
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    anim.SetBool("gliding", false);
                    anim.SetBool("running", false);
                    anim.SetBool("Idle", true);
                    anim.SetInteger("condition", 0);
                    air = false;
                    moveDir = new Vector3(0, 0, 0);
                }
            }

        }*/
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);


        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}

