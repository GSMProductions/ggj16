using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public bool pressed = false;
    public const string GRABABLE_TAG = "grabable";
    public const string PLAYER_TAG = "Player";
    Animator animator;
    
    public Puzzle2Manager p2manager;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	   animator.SetBool("Pressed", pressed);
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == GRABABLE_TAG || other.gameObject.tag == PLAYER_TAG) {
            pressed = true;
            if (p2manager != null) {
                p2manager.Notify(this);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == GRABABLE_TAG || other.gameObject.tag == PLAYER_TAG) {
            pressed = false;
        }
    }
}
