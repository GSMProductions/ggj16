﻿using UnityEngine;
using System.Collections;

public class BellsManager : MonoBehaviour {


    public Bell firstBell;
    public Bell secondBell;
    public Bell thridBell;

    public bool first = false;
    public bool second = false;
    public bool third = false;

    public bool ok = false;
    public Bell[] other_bells;

    // Use this for initialization
    void Start () {
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
	
	}

    public void BellNotify(int id) {
        if(!ok){
            if (second && id == 3) {
                third = true;
                ok = true;
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