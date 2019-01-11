using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Animator animator;
    public Rigidbody rigidBody;
    Camera camera;

	private float inputH;
	private float inputV;
    private bool run;
    private bool jump;

	void Start ()
	{
		animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        camera = Camera.main;
        camera.enabled = true;
        print(camera.ToString());
        run = false;
        jump = false;
	}
	
	void Update ()
	{
		if(Input.GetKeyDown("1"))
		{
			animator.Play("WAIT01", -1, 0f);
		}

		if (Input.GetKeyDown("2"))
		{
			animator.Play("WAIT02", -1, 0f);
		}

		if (Input.GetKeyDown("3"))
		{
			animator.Play("WAIT03", -1, 0f);
		}

		if (Input.GetKeyDown("4"))
		{
			animator.Play("WAIT04", -1, 0f);
		}

		if(Input.GetMouseButtonDown(0))
		{
			int random = Random.Range(0, 2);
			if(random == 0)
			{
				animator.Play("DAMAGED00", -1, 0f);
			}
			else
			{
				animator.Play("DAMAGED01", -1, 0f);
			}
		}

        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        inputH = Input.GetAxis("Horizontal");
		inputV = Input.GetAxis("Vertical");

        animator.SetFloat("inputH", inputH);
        animator.SetFloat("inputV", inputV);
        animator.SetBool("run", run);
        animator.SetBool("jump", jump);

        float moveX = 0f;
        float moveZ = inputV * 60f * Time.deltaTime;

        if(moveZ > 0f)
        {
            moveX = inputH * 30f * Time.deltaTime;
            if(run)
            {
                moveX = moveX * 3f;
                moveZ = moveZ * 3f;
            }

            camera.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 2);
            camera.transform.rotation = Quaternion.Euler(transform.rotation.x + 45, transform.rotation.y, transform.rotation.z);
            
        }
        else
        {
            camera.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2);
            camera.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
        }

        print(camera.transform.position);

        rigidBody.velocity = new Vector3(moveX, 0f, moveZ);
	}
}
