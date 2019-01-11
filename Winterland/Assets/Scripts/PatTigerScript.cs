using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatTigerScript : MonoBehaviour {

    GameObject target;
    public GameObject heart;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update () {
        DetectNeighbour();
    }

    void DetectNeighbour()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            if (hit.collider.CompareTag("Animal"))
            {
                target.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);
                //Debug.Log("Destroyable");

                if (Input.GetMouseButtonDown(0))
                {
                    //Pat
                    Vector3 heartPosition= hit.transform.position;
                    heartPosition.y += 1.5f;
                    RandomMoveController rmc = hit.collider.gameObject.GetComponent<RandomMoveController>();
                    if(!rmc.isAggressive)
                        Instantiate(heart, heartPosition, Quaternion.Euler(-90, 0, 0));
                }
            }
        }
        else
        {
            target.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            //Debug.Log("Did not Hit");
        }
    }
}
