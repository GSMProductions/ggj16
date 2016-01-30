using UnityEngine;
using System.Collections;

public class Puzzle2Manager : MonoBehaviour {

    public Stuck initial_location;
    public TransitionManager manager;
    private bool complete = false;

    private bool started = false;
    public Animation laser_rise;

    // Use this for initialization
    void Start () {
       manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
    }
    
    // Update is called once per frame
    void Update () {
        if (manager.current_puzzle != 2) {
            return;
        }
        print(initial_location.object_in);
        if (initial_location.object_in == null && !started) {
            started = true;
            laser_rise.Play();
        }
    }

}
