using UnityEngine;
using System.Collections;

public class Puzzle1Manager : MonoBehaviour {

    public TransitionManager manager;
    public bool complete = false;

	// Use this for initialization
	void Start () {
	   manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
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
