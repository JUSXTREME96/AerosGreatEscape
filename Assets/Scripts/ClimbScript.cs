using UnityEngine;
using System.Collections;

public class MYCLASSNAME : MonoBehaviour
{


    Transform chController;
    bool inside = false;
    float heightFactor = 3.2f;

    private CharacterController FPSInput;

    void Start()
    {
        FPSInput = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        if (inside == true && Input.GetKey("w"))
        {
            chController.transform.position += Vector3.up / heightFactor;
        }
    }
    [RPC]
    void Test() { }
}