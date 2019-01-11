using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {

    public Rigidbody2D body;
    public Camera camera;
    bool isGrounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Text finishText;
    public Text scoreText;
    public Button exitButton;
    public AudioSource jump;
    public AudioSource point;

    private int score;
    private Vector3 offset;
   
    void Start () {
        body = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        finishText.text = "";
        score = 0;
        offset = Vector3.zero;
        scoreText.text = "Score: 0";
        exitButton.onClick.AddListener(ExitButtonClick);
    }

    void ExitButtonClick()
    {
        Application.Quit();
    }
    
    void FixedUpdate () {
        groundCheck.position = new Vector2(transform.position.x, transform.position.y - 0.9f);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (isGrounded && Input.GetAxis("Vertical") > 0)
        {
            body.AddForce(groundCheck.up * 200f);
            jump.Play();
        }
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + moveHorizontal * 0.3f, transform.position.y);
        transform.Rotate(Vector3.back * moveHorizontal * 15f, Space.World);

        //print(offset);

        if (transform.position.x >= 0 && offset == Vector3.zero)
        {
            offset = camera.transform.position - transform.position;
        }

        if (offset != Vector3.zero)
        {
            camera.transform.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, camera.transform.position.z);
        }

        //camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);

        if(transform.position.y < -15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print(coll.gameObject.transform.tag);
        if (coll.transform.tag == "Star")
        {
            Destroy(coll.gameObject);
            score = score + 1;
            scoreText.text = "Score: " + score;
            point.Play();
        }

        

        if (coll.transform.tag == "Finish")
        {
            finishText.text = "You won!";
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print(coll.transform.tag);
        if (coll.transform.tag == "BreakableWood")
        {
            Destroy(coll.gameObject);
            score = score + 2;
            scoreText.text = "Score: " + score;
            point.Play();
        }
    }
}
