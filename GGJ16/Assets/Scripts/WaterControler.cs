using UnityEngine;
using System.Collections;

public class WaterControler : MonoBehaviour {


    public GameObject[] waterDrops;
    public Stuck stuck = null;
    public bool freeze;
    public int frameWithSilent = 10;
    public int freezeCounter = 0;
    int index = 0;
	// Use this for initialization
	void Start () {
        stuck = GetComponent<Stuck>();
        WakeUp(waterDrops[index]);
	}
	
	// Update is called once per frame
    void Update () {
        if(freeze){
            if(freezeCounter < frameWithSilent){
                freezeCounter++;
            }
            else{
                freeze = false;
                freezeCounter = 0;
            }
        }
        else if(!waterDrops[index].transform.GetChild(0).GetComponent<AudioSource>().isPlaying) {
            SendToSleep(waterDrops[index]);
            index++;
            if(index >= waterDrops.Length) {
                freeze = true;
                index = 0;
            }
            WakeUp(waterDrops[index]);
        }
    }

    bool CheckStuck() {
        if(stuck.object_in != null){
            if(stuck.object_in.gameObject.name == "bowl") {
                return true;
            }
        }
        return false;
    }
    void WakeUp(GameObject waterDrop){
        waterDrop.SetActive(true);
        waterDrop.transform.GetChild(0).GetComponent<AudioSource>().mute = !CheckStuck();
    }

    void SendToSleep(GameObject waterDrop){
        waterDrop.SetActive(false);
    }
}
