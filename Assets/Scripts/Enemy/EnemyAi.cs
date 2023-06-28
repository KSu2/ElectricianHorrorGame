using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    //the agent
    public NavMeshAgent agent;
    public Material matCalm;
    public Material matChase;

    //the player
    public Transform a;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public float sightAngle;
    public bool playerInSightRange;
    private Vector3 lastPlayerPos;

    public float chaseSpeed;
    public float patrolSpeed;

    private void Awake()
    {
        chaseSpeed = 10f;
        patrolSpeed = 5f;
        sightAngle = 30f;
        playerInSightRange = false;
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        //instead of using CheckSphere implement it so that the enemy only chases player when they are in front of them
        /**
         *  Ray r = new Ray(a., a.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, intRange){

            }
         */
        //probably add two speeds as well
        //one for chasing and one for patroling
        //playerInSightRange = Physics.CheckSphere(transform.position, sightRange/3, whatIsPlayer);

        Vector3 playerPos = References.thePlayer.transform.position;
        Vector3 vectorToPlayer = playerPos - transform.position;

        //Default detection
        if((Vector3.Distance(transform.position, playerPos) <= sightRange && Vector3.Angle(transform.forward, vectorToPlayer) <= sightAngle) || 

        //Detection angle is increased if player gets too close
        (Vector3.Distance(transform.position, playerPos) <= sightRange/3 && Vector3.Angle(transform.forward, vectorToPlayer) <= sightAngle*3))
        {
                playerInSightRange = true;
                lastPlayerPos = playerPos;
        }
        else if(Vector3.Distance(transform.position, playerPos) > sightRange)
        {
            playerInSightRange = false;
        }

        if (!playerInSightRange)
        {
            Patroling();

        }

        if (playerInSightRange)
        {
            ChasePlayer();
        } 
    }

    private void Patroling()
    {
        //GetComponent<MeshRenderer>().material = matCalm;
        agent.speed = patrolSpeed;
        //Debug.Log("Patroling");
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //Debug.Log("Walk Point: " + walkPoint);
        walkPoint = lastPlayerPos;

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        //GetComponent<MeshRenderer>().material = matChase;
        //add de-aggro timer
        //add memorize player last position function
        agent.speed = chaseSpeed;
        //Debug.Log("Chasing");
        agent.SetDestination(References.thePlayer.transform.position);
    }


}
