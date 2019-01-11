using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTigersScript : MonoBehaviour {
    
	void Start () {
        int numberOfTigers = (int)Mathf.Floor(Random.Range(1, 5));

        Debug.Log(numberOfTigers + " tigers");
        GameObject tiger = GameObject.FindGameObjectWithTag("Animal");

        for (int i = 0; i < numberOfTigers; i++)
            Instantiate(tiger);
	}
}
