using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnButtonPressed : MonoBehaviour {
    private Animator anim;

    public void OnButtonPressed()
    {
        foreach (Transform child in transform)
        {
            anim = child.GetComponent<Animator>();
            anim.SetBool("isRotating", true);
        }

        Debug.Log("Rotate button pressed");
    }

    public void OnButtonReleased()
    {
        foreach (Transform child in transform)
        {
            anim = child.GetComponent<Animator>();
            anim.SetBool("isRotating", false);
        }

        Debug.Log("Rotate button released");
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
