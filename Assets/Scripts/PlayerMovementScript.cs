using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed = 12f;

    [SerializeField]
    private float speedInAir = 6f;

    [SerializeField]
    private float groundSpeed = 12;

    [SerializeField]
    private float jumpHeight = 3f;

    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance = 0.1f;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private AudioSource audioData;

    private Vector3 velocity;
    private bool isGround;

    //Start is called once at the start
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for ground
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

       

        //Checking if it should add gravity
        if (isGround && velocity.y <0) 
        {
            velocity.y = -2f;
        }

        if (isGround != true)
        {
            speed = speedInAir;
        }
        else
        {
            speed = groundSpeed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Moving not gravity
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //Jumping
        if (Input.GetButtonDown("Jump") && isGround)
        {
            audioData.Play(0);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
       
        //Gravity
        velocity.y += gravity * Time.deltaTime;

        //Moving with gravity
        controller.Move(velocity * Time.deltaTime);
    }
}
