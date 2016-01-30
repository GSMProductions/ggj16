using UnityEngine;
using System.Collections;

public class Stuck : MonoBehaviour {

    public const string GRABABLE_TAG = "grabable";
    public Transform object_in = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == GRABABLE_TAG && !Input.GetMouseButton(0) && object_in == null) {
            object_in = other.transform;
            object_in.position = transform.position;
            object_in.parent=null;
            object_in.GetComponent<Rigidbody>().useGravity = false;
            object_in.GetComponent<Rigidbody>().velocity = Vector3.zero;
            object_in.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    void OnTriggerExit() {
        object_in = null;
    }
}
