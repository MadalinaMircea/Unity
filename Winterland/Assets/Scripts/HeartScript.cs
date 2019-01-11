using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour {

    DateTime start;
    // Use this for initialization
    void Start () {
        start = DateTime.Now;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(0f, 0f, 0.25f * Time.deltaTime);
        if ((DateTime.Now - start).Seconds >= 2)
            Destroy(gameObject);
        //Debug.Log(transform.rotation);
    }
}
