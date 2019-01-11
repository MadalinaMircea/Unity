using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    
    public AudioSource chasing;

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        bool isAggresive = false;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal"))
        {
            RandomMoveController rmc = obj.GetComponent<RandomMoveController>();
            if (rmc.isAggressive)
            {
                isAggresive = true;
                break;
            }
        }

        if(isAggresive)
        {
            if(!chasing.isPlaying)
                chasing.Play();
            Debug.Log("Aggressive");
            
        }
        else
        {
            Debug.Log("Not Aggressive");

            if (chasing.isPlaying)
                chasing.Stop();
        }

	}
}
