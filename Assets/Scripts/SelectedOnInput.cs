using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectedOnInput : MonoBehaviour {
    public EventSystem events;
    public GameObject selected;

    private bool buttonSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw ("Vertical")!=0 && buttonSelected == false)
        {
            Debug.Log(Input.GetAxisRaw("Vertical"));
            events.SetSelectedGameObject(selected);
            buttonSelected = true;
        }
	}
    private void OnDisable()
    {
        buttonSelected = false;
    }
}
