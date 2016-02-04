using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Puzzle1Manager : MonoBehaviour {

    public TransitionManager manager;
    bool started = false;
    public bool complete = false;

    public UnityEvent on_started;

	// Use this for initialization
	void Start () {
	   manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
	}

    public void BallRemovedFromBack() {
        if (manager.current_puzzle == 1 && !started) {
            started = true;
            on_started.Invoke();
        }
    }

    public void CentralPedestalObjectIn(GameObject obj) {
        if (manager.current_puzzle != 1) {
            return;
        }

        if (!complete) {
            manager.LevelComplete(1);
            complete = true;
        }
    }
}
