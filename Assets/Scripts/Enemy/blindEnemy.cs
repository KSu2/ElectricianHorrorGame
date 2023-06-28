using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blindEnemy : MonoBehaviour
{
        //the agent
    public UnityEngine.AI.NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float hearingRange;
    public float sprintMult;
    public float crouchMult;
    public float jumpMod;
    private float hearingRangeMult;


    private bool playerInSightRange;
    private bool pursueLastPosOn;
    private Vector3 lastPlayerPos;

    public float chaseSpeed;
    public float patrolSpeed;

    private void Awake()
    {
        playerInSightRange = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = References.thePlayer.transform.position;
        Vector3 vectorToPlayer = playerPos - transform.position;

        //Sprint increases hearing range
        if(Input.GetButton("Sprint") && playerMovement.sprintDelay == false)
        {
            hearingRangeMult = sprintMult;
        }

        //Crouch decreases hearing range
        if(Input.GetButton("Crouch"))
        {
            hearingRangeMult = crouchMult;
        }

        //Jump increases hearing range
        if(Input.GetButtonDown("Jump") && playerMovement.isGrounded)
        {
            hearingRangeMult *= jumpMod;
        }

        //Detection is based on if player is in the hearing range, moving or jumping, and is grounded
        if(Vector3.Distance(transform.position, playerPos) <= hearingRange * hearingRangeMult && (Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetButton("Jump")) && playerMovement.isGrounded)
        {
            playerInSightRange = true;
        }

        //Player leaves detection range
        else if(Vector3.Distance(transform.position, playerPos) > hearingRange * hearingRangeMult)
        {
            playerInSightRange = false;
        }

        //Behaviors
        if (!playerInSightRange)
        {
            Patroling();
        }

        if (playerInSightRange)
        {
            ChasePlayer();
        } 

        //Reset hearing range to base value
        hearingRangeMult = 1f;

    }

    private void Patroling()
    {
        //Debug.Log("Patroling");
        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }
        
        if (walkPointSet) 
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            if(pursueLastPosOn)
            {
                pursueLastPosOn = false;
            }
        }
    }

    private void SearchWalkPoint()
    {
        

        if(pursueLastPosOn)
        {
            walkPoint = lastPlayerPos;
        }
        else
        {
            agent.speed = patrolSpeed;
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            walkPointSet = true;
        }


        //Debug.Log("Walk Point: " + walkPoint);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(References.thePlayer.transform.position);
        lastPlayerPos = References.thePlayer.transform.position;
        pursueLastPosOn = true;
    }


}
