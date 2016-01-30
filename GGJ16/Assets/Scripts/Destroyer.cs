using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    public static string DECOR_TAG = "decor";

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == DECOR_TAG) {
            Destroy(other.gameObject);
        }
    }

}
