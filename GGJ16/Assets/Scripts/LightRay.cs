using UnityEngine;
using System.Collections;

public class LightRay : MonoBehaviour {
     
    private RaycastHit hit;
    private Ray ray;
    public LineRenderer line;

    public LineRenderer line_from_sphere;

    public Transform ray_target;

    public Transform[] targets;

    // Use this for initialization
    void Start () {
        line_from_sphere.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        
        if(Physics.Raycast(ray, out hit, 100)) {
            line.SetPosition(1, hit.point);
            if (hit.collider.gameObject.tag == "grabable") {
                if (ray_target) {
                    line_from_sphere.enabled = true;   
                    line_from_sphere.SetPosition(0, hit.collider.transform.position);
                    line_from_sphere.SetPosition(1, ray_target.position);
                }
            } else {
                line_from_sphere.enabled = false;
            }              
        }

	}
}
