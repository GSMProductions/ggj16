using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class UpDownMover : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
	   animator = GetComponent<Animator>();
	}
	
    public void SetParameterUp(bool val) {
        animator.SetBool("Up", val);
    }
}
