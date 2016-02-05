using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Puzzle5Manager : MonoBehaviour {

    public Stuck stuck;
    public TransitionManager manager;
    public bool complete = false;

    public UnityEvent on_started;
    bool started = false;

	// Use this for initialization
	void Start () {
	   manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
	}

    public void BallTakenFromCenter() {
        if (manager.current_puzzle == 5 && !started) {
            started = true;
            on_started.Invoke();
        }
    }
	
    public void BallInTheBack() {
        if (manager.current_puzzle == 5 && !complete) {
            complete = true;
            manager.LevelComplete(5);
        }
    }

}
