using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;
    public GameObject target;

    public bool jumping = false;

    // Use this for initialization
    void Start () {
        character = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            jumping = true;
        }
        else
        {
            jumping = false;

            MouseAiming();
            DetectNeighbour();
        }
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
            if(hit.collider.CompareTag("Interactable"))
            {
                target.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);
                Debug.Log("Interactable");

                if (Input.GetMouseButton(0))
                {
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    rb.AddForceAtPosition(new Vector3(hit.point.x, 0, hit.point.z), hit.point);
                }
            }
        }
        else
        {
            target.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            Debug.Log("Did not Hit");
        }
    }

    void MouseAiming()
    {
        //get change in mouse movement
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseChange = Vector2.Scale(mouseChange, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        //Lerp makes a linear interpretation of the movement so that it is smooth from one point to the other
        smoothV.x = Mathf.Lerp(smoothV.x, mouseChange.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseChange.y, 1f / smoothing);

        //total mouse movement
        mouseLook += smoothV;

        //limit the vertical rotation of the camera
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //rotate camera around the horizontal line
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        //rotate the whole character around the vertical line
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
