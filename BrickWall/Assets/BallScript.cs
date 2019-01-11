using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	DateTime startScript = new DateTime();
	DateTime startCollision = new DateTime();
	// Use this for initialization
	void Start () {
		startScript = DateTime.Now;
		startCollision = startScript;
	}
	
	// Update is called once per frame
	void Update () {
		if (!DateTime.Equals(startCollision, startScript) && DateTime.Now - startCollision >= TimeSpan.FromSeconds(1))
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Brick")
		{
			if (DateTime.Equals(startCollision, startScript))
			{
				startCollision = DateTime.Now;
			}
		}
	}
}
