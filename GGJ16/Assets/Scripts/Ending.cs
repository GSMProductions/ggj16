using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Ending : MonoBehaviour {

    public AudioMixerSnapshot bgm;
    public GameObject all;

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            bgm.TransitionTo(2.0f);
            Destroy(all); 
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
