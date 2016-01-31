using UnityEngine;
using System.Collections;

[RequireComponent (typeof (InteractiveObject))]
public class MouseRotate : MonoBehaviour {

    public float speed;
    public float friction;

    public float lerpSpeed;

    private float xDeg;
    private float yDeg;

    private Quaternion fromRotation;
    private Quaternion toRotation;

    void Update () {
        if(Input.GetMouseButton(0) && GetComponent<InteractiveObject>().active) {
            xDeg += Input.GetAxis("Mouse X") * speed * friction;
            yDeg -= Input.GetAxis("Mouse Y") * speed * friction;
        }
        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(yDeg,xDeg,0);
        transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime  * lerpSpeed);
    }
}
