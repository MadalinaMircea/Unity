using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour {

    GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.tag);
    }
}
