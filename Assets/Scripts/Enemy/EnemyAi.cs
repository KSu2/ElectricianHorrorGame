using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    //the agent
    public NavMeshAgent agent;

    //the player
    public Transform player;
    public Transform a;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public bool playerInSightRange;

    public float chaseSpeed;
    public float patrolSpeed;

    private void Awake()
    {
        chaseSpeed = 10f;
        patrolSpeed = 5f;
        player = GameObject.Find("firstPersonPlayer").transform;
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
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        if (playerInSightRange) ChasePlayer();
    }

    private void Patroling()
    {
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

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        //add de-aggro timer
        //add memorize player last position function
        agent.speed = chaseSpeed;
        //Debug.Log("Chasing");
        agent.SetDestination(player.position);
    }


}
