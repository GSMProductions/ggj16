using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public bool pressed = false;

    Animator animator;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	   animator.SetBool("Pressed", pressed);
	}

    void OnTriggerEnter() {
        pressed = true;
    }

    void OnTriggerExit() {
        pressed = false;
    }
}
