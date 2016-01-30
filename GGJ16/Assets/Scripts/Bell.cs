using UnityEngine;
using System.Collections;

public class Bell : MonoBehaviour {

    public BellsManager manager = null;
    public int bellId = 0;

    void Start() {

    }
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        if(Input.GetMouseButtonDown(0) && !GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().Play();
            manager.BellNotify(bellId);
            }
    }
}
