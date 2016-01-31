using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Ending : MonoBehaviour {

    public AudioMixerSnapshot bgm;
    public GameObject all;
    public GameObject credits;

	// Use this for initialization
	void Start () {
	
	}

    IEnumerator DelayExit(float delay) {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            bgm.TransitionTo(2.0f);
            Destroy(all); 
            credits.SetActive(true);
            StartCoroutine(DelayExit(30f));
        }
    }
    
    // Update is called once per frame
    void Update () {

    }

}