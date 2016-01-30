using UnityEngine;
using System.Collections;

public class RemoveDecor : MonoBehaviour {
    public bool remove_object = false;
    public Vector3 accelaration = Vector3.zero;
    public Vector3 accelaration_max = Vector3.zero;
    public Collider room_collider;

    void Start() {

        Physics.IgnoreCollision(room_collider, GetComponent<Collider>());
        
        float x, y, z;
        x = accelaration.x;
        y = accelaration.y;
        z = accelaration.z;

        if (x < accelaration_max.x) {
            x = accelaration_max.x;
        }

        if (y < accelaration_max.y) {
            y = accelaration_max.y;
        }

        if (z < accelaration_max.z) {
            z = accelaration_max.z;
        }

        accelaration_max = new Vector3(x, y, z);
    }
    void Update () {

        if (remove_object) {
            UpdateVelocity();
        }
        else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
        }
    }

    private void UpdateVelocity() {
        float x, y, z;
        GetComponent<Rigidbody>().AddForce(accelaration);
        x = GetComponent<Rigidbody>().velocity.x;
        y = GetComponent<Rigidbody>().velocity.y;
        z = GetComponent<Rigidbody>().velocity.z;

        if (x > accelaration_max.x) {
            x = accelaration_max.x;
        }

        if (y > accelaration_max.y) {
            y = accelaration_max.y;
        }

        if (z > accelaration_max.z) {
            z = accelaration_max.z;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(x,y,z);
    }
}
