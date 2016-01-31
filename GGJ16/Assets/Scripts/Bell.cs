using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class Bell : MonoBehaviour {

    public BellsManager manager = null;
    public int bellId = 0;

    void Start() {

    }
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        if(Input.GetMouseButtonDown(0)) {
            GetComponent<AudioSource>().Play();
            manager.BellNotify(bellId);
            }
    }
}
