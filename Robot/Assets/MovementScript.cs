using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    float HipMaxRotationBackwards = 0.3f;
    float HipMaxRotationForward = -0.3f;
    float KneeMaxRotation = 0.5f;

    public GameObject RightHip;
    public GameObject LeftHip;
    public GameObject RightKnee;
    public GameObject LeftKnee;
    public GameObject RightShoulder;
    public GameObject LeftShoulder;
    public GameObject RightElbow;
    public GameObject LeftElbow;

    public float RotationSpeed;
    
    bool LeftMovingForward;
    // Use this for initialization
    void Start () {
        LeftMovingForward = true;
        //LeftHip.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        //RightHip.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
    }
    
    
    // Update is called once per frame
    void Update ()
    {
        if (LeftMovingForward)
        {
            LeftHip.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
            RightHip.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }

        if(LeftHip.transform.rotation.x < HipMaxRotationForward)
        {
            LeftMovingForward = false;
        }

        if (LeftHip.transform.rotation.x > HipMaxRotationBackwards)
        {
            LeftMovingForward = true;
        }

        if (!LeftMovingForward)
        {
            RightHip.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
            LeftHip.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }

        if (!LeftMovingForward)
        {
            RightShoulder.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
            LeftShoulder.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        }

        if (LeftMovingForward)
        {
            LeftShoulder.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
            RightShoulder.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        }





        if (LeftMovingForward)
        {
            LeftKnee.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
            RightKnee.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }

        if (!LeftMovingForward)
        {
            RightKnee.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
            LeftKnee.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }

        if (!LeftMovingForward)
        {
            RightElbow.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
            LeftElbow.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        }

        if (LeftMovingForward)
        {
            LeftElbow.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
            RightElbow.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        }

        //if(LeftKnee.transform.rotation.x > -KneeMaxRotation)
        //{
        //    LeftKnee.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        //}
        //    }
        //    else
        //    {
        //        LeftMovingForward = false;
        //    }

        //    if (RightHip.transform.rotation.x < HipMaxRotationBackwards)
        //    {
        //        RightHip.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);

        //        if (RightKnee.transform.rotation.x < KneeMaxRotation)
        //        {
        //            RightKnee.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        //        }
        //    }
        //}

        //if (!LeftMovingForward)
        //{
        //    if (RightHip.transform.rotation.x > HipMaxRotationForward)
        //    {
        //        RightHip.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);

        //        if (RightKnee.transform.rotation.x > -KneeMaxRotation)
        //        {
        //            RightKnee.transform.Rotate(-1 * Vector3.right * RotationSpeed * Time.deltaTime);
        //        }
        //    }
        //    else
        //    {
        //        LeftMovingForward = true;
        //    }

        //    if (LeftHip.transform.rotation.x < HipMaxRotationBackwards)
        //    {
        //        LeftHip.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);

        //        if (LeftKnee.transform.rotation.x < KneeMaxRotation)
        //        {
        //            LeftKnee.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        //        }
        //    }
    }
}
