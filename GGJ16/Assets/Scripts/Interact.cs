using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public const string INTERACTIVE_TAG = "interactive";
    public InteractiveObject interactive_object = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(interactive_object != null) {
	        if(Input.GetMouseButton(0)) {
                interactive_object.active = true;
            } else {
                interactive_object.active = false;
            }
        }
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == INTERACTIVE_TAG) {
            interactive_object = other.gameObject.GetComponent<InteractiveObject>();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<InteractiveObject>() &&  other.gameObject.GetComponent<InteractiveObject>() == interactive_object) {
            interactive_object.active = false;
            interactive_object = null;
        }
    }

}
