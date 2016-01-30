using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

public const string GRABABLE_TAG = "grabable";
public Transform object_grabable = null;
Quaternion originalRotation = Quaternion.identity;

    void Update() {
        if(Input.GetMouseButton(0)) {
            if(object_grabable != null) {
                grab();
            }
        } 
        else {
            if(object_grabable != null) {
                unGrab();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == GRABABLE_TAG && object_grabable == null) {
            object_grabable = other.transform;
            originalRotation = object_grabable.transform.rotation;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.transform == object_grabable) {
            object_grabable = null;
        }
    }

    private void grab() {
        try{
            object_grabable.GetComponent<Rigidbody>().useGravity = false;
            object_grabable.GetComponent<Rigidbody>().velocity = Vector3.zero;
            object_grabable.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        catch{
        }
        object_grabable.parent = transform;
        object_grabable.position = transform.position;
    }

    private void unGrab() {
        try{
            object_grabable.GetComponent<Rigidbody>().useGravity = true;
            object_grabable.transform.rotation = originalRotation;
        }
        catch{
        }
        object_grabable.parent = null;
    }
}
