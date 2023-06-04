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
    //stamina value for the user initialized to 10
    public float stamina = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float doubleJump = 0;
    float jumpTime = 0f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float multiplier = 1f;

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

        //check if shift is being pressed
        if(Input.GetButton("Sprint"))
        {
            multiplier = 3f;
            stamina -= 1f;
            //DEBUG statement
            Debug.Log("I am sprint");
        } else
        {
            multiplier = 1f;
            stamina += 1f;
            //DEBUG
            Debug.Log("I am not sprint");
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //DEBUG
        Debug.Log("Current speed: " + speed);
    
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
        controller.Move(velocity * multiplier * Time.deltaTime);

        
    }
}
