using UnityEngine;
using System.Collections;

public class BellsManager : MonoBehaviour {


    public Bell firstBell;
    public Bell secondBell;
    public Bell thridBell;
    Animator animator;
    public bool first = false;
    public bool second = false;
    public bool third = false;
    public TransitionManager manager;
    public bool ok = false;
    public Bell[] other_bells;
    public Animation[] to_rise;
    public Animation[] to_plunge;
    bool started = false;

    public bool complete = false;
    public GameObject bowl;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
       firstBell.manager = this;
       firstBell.bellId = 1;

       secondBell.manager = this;
       secondBell.bellId = 2;

       thridBell.manager = this;
       thridBell.bellId = 3;

       for(int index=0; index < other_bells.Length; index++){
            other_bells[index].bellId = index+4;
            other_bells[index].manager = this;
       }
	}
	
	// Update is called once per frame
	void Update () {
        if (complete || manager.current_puzzle != 3) {
            return;
        } else{
            animator.SetBool("Start", true);
            bowl.SetActive(true);
            if (!started) {
                started = true;
                foreach (Animation rise in to_rise) {
                    rise.Play();
                }
            }
        }

	}

    public void BellNotify(int id) {
        if(!ok){
            if (second && id == 3) {
                third = true;
                ok = true;
                manager.LevelComplete(3);
                animator.SetBool("Start", false);
                bowl.SetActive(false);
                foreach(Animation plunge in to_plunge) {
                    plunge.Play();
                }
            }
            else if (first && id == 2 && !second){
                second = true;
            }
            else if (id == 1 && !first) {
                first = true;
            }
            else {
                if(id != 1)first = false;
                second = false;
                third = false;
            }
        }
    }
}
