using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public float speed = 7.5f;

    //public float maxHeight = 3.5f;
    //public float minHeight;

    private float timer = 0.0f;
    float stepSpeed = 0.2f;
    public float height = 0.25f;
    public float midpoint = 22.0f;

    public float horizontal = 0f;
    public float vertical = 0f;

    public bool goingUp = true;

    public bool jumping = false;

    void Start()
    {
        //locks mouse so you don't see it and can't use it
        Cursor.lockState = CursorLockMode.Locked;
        //minHeight = transform.position.y;
        midpoint = transform.position.y;
    }

    void Update()
    {
        KeyboardMovement();
        Step();
    }
    
    void KeyboardMovement()
    {
        if(!jumping)
        {
            //auxiliary speed variable
            float s = speed;

            //sprint when holding down left shift
            if (Input.GetKey(KeyCode.LeftShift))
                s = s * 2;

            //z axis movement
            horizontal = Input.GetAxis("Vertical");
            float translation = horizontal * s * Time.deltaTime;

            //x axis movement
            vertical = Input.GetAxis("Horizontal");
            float straffe = vertical * s * Time.deltaTime;

            float jumpHeight = 0;

            transform.Translate(straffe, jumpHeight, translation);
        }

        if(Input.GetKeyDown("escape"))
        {
            //unlocks mouse
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Step()
    {
        if (!jumping)
        {
            float waveslice = 0.0f;

            Vector3 position = transform.localPosition;

            //auxiliary speed variable
            float s = stepSpeed;

            //sprint when holding down left shift
            if (Input.GetKey(KeyCode.LeftShift))
                s = s * 2;

            //check if the character is moving
            if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
            {
                //if it is not moving, do not do headbob
                timer = 0.0f;
            }
            else
            {
                //if it is moving
                //we use the graph of the sine function to determine the shape of the headbob
                waveslice = Mathf.Sin(timer);

                //timer represents how much time passed since the last time headbob was called
                timer = timer + s;
                if (timer > Mathf.PI * 2)
                {
                    timer = timer - (Mathf.PI * 2);
                    
                }
            }

            //if we need to do headbob
            if (waveslice != 0)
            {
                //compute height based on the sine value at this time step
                float translateChange = waveslice * height;

                //helps smooth the movement, makes it not snap in place
                float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;

                //compute final position
                position.y = midpoint + translateChange;
            }
            else
            {
                //if we do not need to do headbob, remain at midpoint
                position.y = midpoint;
            }

            //update position
            transform.localPosition = position;
        }
    }
}
