using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float doubleJumps = 1;
    public float coyoteTime = 1f;
    public float sprintMult = 1.5f;
    public float crouchMult;
    //stamina value for the user initialized to 10
    public float maxStam = 5f;
    float stamina;
    float multiplier = 1f;
    public static bool sprintDelay;
    public float sprintDelayTime = 4f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public static bool isGrounded;
    float doubleJump = 0;
    float jumpTime = 0f;

    //reference to script which updates stam and health bars
    public updateBars up;

    //use the item that is currently equipped
    public void useItem(int type)
    {

    }

    void Start()
    {
        References.thePlayer = gameObject;
        stamina = maxStam;
    }
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
            doubleJump = 0;
            jumpTime = coyoteTime;
        }

        if(!isGrounded)
        {
            jumpTime -= Time.deltaTime;
        }

        multiplier = 1f;

        //check if shift is being pressed
        if(Input.GetButton("Sprint") && sprintDelay == false)
        {
            if(stamina > 0)
            {
                multiplier = sprintMult;
                stamina -= Time.deltaTime;
                //DEBUG statement
                //Debug.Log("I am sprint");
            }
            else if(stamina <= 0)
            {
                sprintDelay = true;
                StartCoroutine(DelayFunc());
            }
        } 

        else if (stamina <= maxStam)
        {
            stamina += Time.deltaTime;
            //DEBUG
            //Debug.Log("I am not sprint");
        }

        //Crouch
        if(Input.GetButton("Crouch"))
        {
            //References.theCamera.transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
            multiplier = crouchMult;
        }

        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //DEBUG
        //Debug.Log("Current speed: " + speed);
    
        controller.Move(move * speed * multiplier * Time.deltaTime);
        

        //first jump condition
        if(Input.GetButtonDown("Jump") && (jumpTime > 0f || isGrounded))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpTime -= jumpTime;
        }

        //double jump condition
        if(Input.GetButtonDown("Jump") && doubleJump < doubleJumps && !isGrounded && jumpTime <= 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump += 1;
        }

        velocity.y += gravity * Time.deltaTime;

        //move controller position
        controller.Move(velocity * Time.deltaTime);
        up.updateStam(stamina/maxStam);
    }

    IEnumerator DelayFunc()
    {
            yield return new WaitForSeconds(sprintDelayTime);
            sprintDelay = false;
    }
}
