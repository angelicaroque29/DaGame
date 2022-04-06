using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    private CharacterController controller;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;

    [SerializeField]
    private float jumpHorizontalSped;

    private bool isJumping;
    private bool isGrounded;
    private bool isFalling;
    private bool isRunning;
    private bool isWalking;

    void Start()
    {
    	controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if(controller.isGrounded)
        {
        	verticalVelocity = -gravity * Time.deltaTime;
        	anim.SetBool("isGrounded", true);
        	isGrounded = true;
        	anim.SetBool("isJumping", false);
        	isJumping = false;
        	anim.SetBool("isFalling", false);

        	if(Input.GetKeyDown(KeyCode.Space))
        	{
            
        		verticalVelocity = jumpForce;
        		anim.SetBool("isJumping", true);
        		isJumping = true;

        	}
        	if(Input.GetKeyDown(KeyCode.R))
        	{
        		anim.SetBool("isRunning", true);
        		isRunning = true;
        	}
        	if(Input.GetKeyDown(KeyCode.W))
        	{
        		anim.SetBool("isRunning", false);
        		isRunning = false;
        	}
            if(Input.GetKeyDown(KeyCode.M))
            {
                anim.SetBool("isWalking", true);
                isWalking = true;
            }
        }

        else
        {
        	verticalVelocity -= gravity * Time.deltaTime;
        	anim.SetBool("isGrounded", false);
        	isGrounded = false;

        	if((isJumping && verticalVelocity < 0) || verticalVelocity < -2)
        	{
        		anim.SetBool("isFalling", true);
        	}
        }

        Vector3 moveVector = Vector3.zero;
        // moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
        moveVector.y = verticalVelocity;
        // moveVector.z = Input.GetAxis("Vertical") * 5.0f;
        controller.Move(moveVector * Time.deltaTime);

        if(isGrounded == false)
        {
        	Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSped;
        	velocity.y = verticalVelocity;

        	controller.Move(velocity * Time.deltaTime);
        }
       
    }

   
}
