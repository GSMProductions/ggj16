using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class LightRay : MonoBehaviour {
     
    private RaycastHit hit;
    private Ray ray;
    public LineRenderer line;

    public LineRenderer line_from_sphere;

    public Transform ray_target;

    public Transform[] targets;

    public Stuck[] placements;

    public UnityEvent on_first_shine;
    public UnityEvent on_second_shine;
    bool first_shine = false;
    bool second_shine = false;

    // Use this for initialization
    void Start () {
        line_from_sphere.enabled = false;
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        Vector3 endPoint = transform.position + transform.forward * 100000;
        line.SetPosition(1, endPoint);
    }
    
    // Update is called once per frame
    void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
    
        bool found = false;
        for (int i = 0; i < placements.Length; i++) {
            if (placements[i].object_in != null) {
                ray_target = targets[i];
                found = true;
            }
        }
        if (!found) {
            ray_target=null;
        }

        if(Physics.Raycast(ray, out hit, 100)) {
            line.SetPosition(1, hit.point);
            if (hit.collider.gameObject.tag == "grabable") {
                if (ray_target) {
                    line_from_sphere.enabled = true;   
                    line_from_sphere.SetPosition(0, hit.collider.transform.position);
                    line_from_sphere.SetPosition(1, ray_target.position);
                    if (ray_target == targets[0] && !first_shine) {
                        on_first_shine.Invoke();
                        first_shine = true;
                    } else if (ray_target != null && ray_target != targets[0] && !second_shine) {
                        on_second_shine.Invoke();
                        second_shine = true;
                    }

                }
            } else {
                line_from_sphere.enabled = false;
            }              
        } else {
            Vector3 endPoint = transform.position + transform.forward * 100000;
            line.SetPosition(1, endPoint);
        }

	}
}
