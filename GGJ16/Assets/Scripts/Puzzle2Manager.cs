using UnityEngine;
using System.Collections;

public class Puzzle2Manager : MonoBehaviour {

    public Stuck initial_location;
    public TransitionManager manager;
    private bool complete = false;

    private bool started = false;
    public Animation[] to_rise;

    public PressurePlate[] sequence;

    public PressurePlate[] entered_sequence;
    private int number_pressed = 0;

    // Use this for initialization
    void Start () {
       manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
        foreach (PressurePlate plate in sequence) {
            plate.p2manager = this;
        }
        entered_sequence = new PressurePlate[sequence.Length];
    }
    
    // Update is called once per frame
    void Update () {
        if (complete || manager.current_puzzle != 2) {
            return;
        }
        if (initial_location.object_in == null && !started) {
            started = true;
            foreach(Animation rise in to_rise) {
                rise.Play();
            }
        }
    }

    public void Notify(PressurePlate plate) {
        entered_sequence[number_pressed] = plate;
        number_pressed += 1;
        for (int i = 0; i < number_pressed; i++) {
            if (entered_sequence[i] != sequence[i]) {
                if (entered_sequence[i] == sequence[0]) {
                    entered_sequence = new PressurePlate[sequence.Length];
                    entered_sequence[0] = sequence[0];
                    number_pressed = 1;
                } else {
                    entered_sequence = new PressurePlate[sequence.Length];
                    number_pressed = 0;
                }
                return;
            }
        }
        if (number_pressed == sequence.Length) {
            manager.LevelComplete(2);
            complete = true;
            GetComponent<Animation>().Play();
        }
    }

}
