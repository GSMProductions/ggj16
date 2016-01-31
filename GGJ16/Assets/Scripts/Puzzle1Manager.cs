using UnityEngine;
using System.Collections;

public class Puzzle1Manager : MonoBehaviour {

    public Stuck stuck;
    public TransitionManager manager;
    public bool complete = false;

	// Use this for initialization
	void Start () {
	   manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (stuck.object_in != null && !complete) {
            manager.LevelComplete(1);
            complete = true;
        }
	}
}
