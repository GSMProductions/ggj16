using UnityEngine;
using System.Collections;

public class BrokenBallManager : MonoBehaviour {

    public GameObject[] partOfBall;
    public GameObject[] pieces;
    public int index = -1;
    public bool begin = false;

    public bool explode = false;
    public float explodePower = 10f;
    public Grab grab;
    public Stuck stuckTrigger;
    public TransitionManager manager;


	// Use this for initialization
	void Start () {
    manager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
	}
	
	// Update is called once per frame
	void Update () {
            if(manager.current_puzzle == 4 && !explode) {

                if(stuckTrigger.object_in != null){
                    begin = true;
                    Destroy(stuckTrigger.object_in.gameObject);
                    grab.on_grab = false;
                    grab.object_grabable = null;
                    stuckTrigger.gameObject.SetActive(false);

                }
            }
                
        if(!explode && begin){
            foreach(GameObject piece in pieces) {
                piece.SetActive(true);
    /*            Vector3 rnd;*/
    /*            rnd.x = Random.Range (-explodePower, explodePower);
                rnd.y = Random.Range (-explodePower, explodePower);
                rnd.z = Random.Range (-explodePower, explodePower);
                piece.GetComponent<Rigidbody>().AddForce(rnd);*/
                piece.GetComponent<Rigidbody>().useGravity = true;
                piece.GetComponent<Collider>().enabled = true;
                }
                explode = true;
            }
        if (explode && begin && grab.on_grab) {
            print("You can Assemble");
            GetComponent<Collider>().enabled = true;
        }
    }

    public void AddPiece () {
        if(index >= 0 && index < 3) {
            print("remove old");
            partOfBall[index].SetActive(false);
        }
        index++;
        if(index < partOfBall.Length){
            print("add piece: " + partOfBall[index].name);
            partOfBall[index].SetActive(true);
        }
        else{
            GetComponent<Collider>().enabled = false;
            stuckTrigger.gameObject.SetActive(true);
        }
    }
}
