using UnityEngine;
using System.Collections;

public class LightRay : MonoBehaviour {
     
    private RaycastHit hit;
    private Ray ray;
    public LineRenderer line;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        
        if(Physics.Raycast(ray, out hit, 100))
        {
            line.SetPosition(1, hit.point);
            if (hit.collider.gameObject.tag == "grabable") {
                // We hit the sphere
            }
        }

	}
}
