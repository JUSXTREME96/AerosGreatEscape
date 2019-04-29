using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVideo : MonoBehaviour {
    public GameObject movieStop;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Disable() {
        movieStop.SetActive(false);
    }
    public void Enable()
    {
        movieStop.SetActive(true);
    }
}
