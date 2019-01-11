using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotatorScript : MonoBehaviour {

    //public Rigidbody2D body;
    // Use this for initialization
    void Start () {
        //body = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        //body.transform.rotation = new Quaternion(body.transform.rotation.x, body.transform.rotation.y, body.transform.rotation.z - 10f, body.transform.rotation.w);
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, z, transform.rotation.w);
        transform.Rotate(Vector3.back * 10f, Space.World);
    }
}
