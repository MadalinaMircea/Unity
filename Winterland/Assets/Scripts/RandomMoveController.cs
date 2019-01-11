using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RandomMoveController : MonoBehaviour {

    NavMeshAgent navMeshAgent;

    Animator animator;

    GameObject player;
    
    bool isInCoroutine;
    bool isWalking;
    bool isRunning;
    bool validPath;

    Vector3 previousPosition;
    Vector3 target;

    public float range = 10.0f;
    public float timeForNewPath;
    public float walkingSpeed = 2;
    public float runningSpeed = 5;

    public bool isAggressive;
    public bool isStopped;

    AudioSource killSound;

    void Start()
    {
        Vector3 point;
        if(RandomPoint(transform.position, range, out point))
        {
            transform.position = point;
        }
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        previousPosition = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");

        isAggressive = false;
        
        navMeshAgent.speed = walkingSpeed;

        killSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.tag);
        if(collision.collider.gameObject.CompareTag("Player") && isAggressive)
        {
            killSound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }

    void Update()
    {
        isStopped = navMeshAgent.isStopped;
        //Vector3 distance = player.transform.position - transform.position;

        if (Input.GetKeyDown(KeyCode.R))
        {
            isAggressive = true;
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance >= 30)
            isAggressive = false;

        NavMeshHit hit;
        if (!NavMesh.SamplePosition(player.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            isAggressive = false;
        }

        if (isAggressive)
        {
            //Debug.Log("Aggressive");
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.speed = runningSpeed;
            navMeshAgent.isStopped = false;
            isRunning = true;
            isWalking = false;
        }

        if (!isAggressive)
        {
            //Debug.Log(player.transform.position + " " + transform.position + " " + distance);

            if (Mathf.Abs(distance) <= 5)
            {
                navMeshAgent.isStopped = true;
                //Debug.Log("Player close");
            }
            else
            {
                navMeshAgent.isStopped = false;
                float shouldWalk = 0;
                if (!isInCoroutine)
                {
                    shouldWalk = Mathf.Floor(Random.Range(0, 100));
                    if (shouldWalk == 1)
                    {
                        StartCoroutine(DoSomething());
                    }
                    else
                    {
                        navMeshAgent.isStopped = true;
                        StartCoroutine(Wait());
                    }
                    //Debug.Log((shouldWalk <= 2 ? "true" : "false") + " " + navMeshAgent.isStopped);
                }

            }
        }

        

        if (Mathf.Abs(Vector3.Distance(transform.position, previousPosition)) <= 0.001)
        {
            isWalking = false;
            isRunning = false;
        }
        else
        {
            if (!isAggressive)
                isWalking = true;
            else
                isRunning = true;
        }

        ModifyParameters();

        previousPosition = transform.position;
    }

    Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(2, 10);
        float z = Random.Range(2, 10);

        if (Random.Range(0, 1) == 0)
            x = -x;

        if (Random.Range(0, 1) == 1)
            z = -z;

        return new Vector3(transform.position.x + x, 0, transform.position.z + z);
    }

    void ModifyParameters()
    {
        animator.SetBool("walking", isWalking);
        animator.SetBool("running", isRunning);
    }

    IEnumerator DoSomething ()
    {
        isInCoroutine = true;
        //ModifyParameters();

        GetNewPath();
        //Debug.Log(target);
        yield return new WaitForSeconds(timeForNewPath);
        

        //validPath = navMeshAgent.CalculatePath(target, path);

        //int counter = 0;
        //while (!validPath)
        //{
        //    Debug.Log("...........Invalid path............");
        //    GetNewPath();
        //    validPath = navMeshAgent.CalculatePath(target, path);
        //    counter++;
        //    if (counter == 10)
        //        break;
        //}

        //if(counter < 10)
        //    Debug.Log("!!!!!!!!!Valid path!!!!!!!!!!!");

        isInCoroutine = false;
        //ModifyParameters();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeForNewPath);
    }

    void GetNewPath()
    {
        target = GenerateRandomPosition();
        navMeshAgent.SetDestination(target);
    }
}
