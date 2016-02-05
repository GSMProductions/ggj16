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

    IEnumerator DelaySetParameterUp(float delay, bool val) {
        yield return new WaitForSeconds(delay);
        animator.SetBool("Up", val);
    }

    public void DelayUp(float delay) {
        StartCoroutine(DelaySetParameterUp(delay, true));
    }

    public void DelayDown(float delay) {
        StartCoroutine(DelaySetParameterUp(delay, false));
    }    

}
