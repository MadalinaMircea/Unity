using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public GameObject ballPrefab;
    public float forwardForce = 1000f;
    public float upwardForce = 200f;
    public float sideForce = 200f;
    
    void Start () {
    }
    
    void Update () {
        if(Input.GetKeyDown("space"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
            Vector3 camera = Camera.main.gameObject.transform.position;
            GameObject ball = Instantiate(ballPrefab, new Vector3(pos.x, pos.y + camera.y, camera.z), Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(pos.x * sideForce, pos.y * upwardForce, forwardForce);
        }
    }
}
