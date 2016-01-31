using UnityEngine;
using System.Collections;

public class FinalStuck : MonoBehaviour {

    public const string GRABABLE_TAG = "grabable";
    public BrokenBallManager manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay(Collider other) {
        if(manager.begin) {
            if(other.gameObject.tag == GRABABLE_TAG && !Input.GetMouseButton(0)) {
                if(manager.index < 3){
                print("Destroy: " + other.gameObject.name);
                Destroy(other.gameObject);
                }
                manager.AddPiece();
            }
        }
    }

}
