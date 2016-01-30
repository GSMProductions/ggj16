﻿using UnityEngine;
using System.Collections;

public class TransitionManager : MonoBehaviour {

    public RemoveDecor[] backdrops;
    public float[] timings;

    private int backdrops_left = 0;
    private int backdrops_removed = 0;

    private float timer;


    void Start() {
        
    }
    
    IEnumerator DelayRemoveBackdrop(float delay, int backdrop) {
        yield return new WaitForSeconds(delay);
        print("Go!");
        backdrops[backdrop].remove_object = true;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void LevelComplete(int puzzle) {
        switch (puzzle) {
            case 1:
            print("Puzzle 1 completed!");
            backdrops_left = 3;
            break;
        }
        for (int i = 0; i < backdrops_left; i++) {
            StartCoroutine(DelayRemoveBackdrop(timings[i], i+backdrops_removed));
        }
        backdrops_removed += backdrops_left;
        backdrops_left = 0;

    }
}