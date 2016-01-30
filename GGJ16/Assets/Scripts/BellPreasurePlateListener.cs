using UnityEngine;
using System.Collections;

public class BellPreasurePlateListener : MonoBehaviour {

    public PressurePlate plate;
    Animator animator;
	// Use this for initialization
	void Start () {
	   animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(plate.pressed) {
            animator.SetBool("triggered", true);
        }
        else {
            animator.SetBool("triggered", false);
        }
	}
}
