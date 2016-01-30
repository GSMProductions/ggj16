using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour {

    public bool active;
    public bool one_shot;

    private float sensitivity_x;
    private float sensitivity_y;

    void Update() {
        if (active && !one_shot) {

        }
    }

    void OnTriggerEnter() {

    }

    void OnTriggerExit() {
        
    }
}
