using UnityEngine;
using System.Collections;

public class Puzzle5Manager : MonoBehaviour {

    public Stuck stuck;
    public TransitionManager manager;
    public bool complete = false;

	// Use this for initialization
	void Start () {
	   manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if ((manager.current_puzzle == 5) && (stuck.object_in != null) && (!complete)) {
            print("Level 5 done");
            manager.LevelComplete(5);
            complete = true;
        }
	}
}
