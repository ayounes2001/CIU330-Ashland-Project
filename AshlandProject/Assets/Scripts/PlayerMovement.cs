using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // public NewJump playerjump;
    [Header("Player Animation State")]
    public PlayerAnimations playerAnimate;      //ANIMATIONS : 0 = idle , 1 = walking , 2 = jumping , 3 = running , 4 = in air 
    public Rigidbody rb;
    bool grounded;

    [Header("Player Speeds")]
    public int walkSpeed;
    public int runSpeed;
    public float currentSpeed;
    public float stamina = 5;
    public float maxStamina = 5;
    public Vector2 input;

   [Header("Player Movement Smoothing")]
    [SerializeField] private float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;
    public float speedSmoothTime = 0.01f;
    private float speedSmoothVelocity;

    [Header ("UI and Camera")]
    public Slider slider;
    public Transform cameraT;

    private void Start()
    {
        cameraT = Camera.main.transform;
        stamina = maxStamina;
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
           
        //***** UI CODE *****
        if(slider != null)
        {
            slider.value = stamina;
            slider.maxValue = maxStamina;
        }
        Movement();

    }
   

    private void Movement()
    {
        grounded = gameObject.GetComponent<NewJump>().isGrounded;
        //using the old Unity Input System
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDirection = input.normalized;

        //trying to call the turning animation once its ugly afff sorrryy

        //Basing our Input on the direction of the camera and smoothing it out
        if (inputDirection != Vector2.zero && gameObject.GetComponent<NewJump>().isGrounded == true)
        {
            playerAnimate.CurrentAnimation = AnimationStates.walking;                //switching to walking animation     
            print("moving");
            float targetRotation =
                (Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y);
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                ref turnSmoothVelocity, turnSmoothTime);
        }

        //Changing inbetween normal speed and runningSpeed and actually moving the player
        bool running = Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Sprint");
        float targetSpeed = ((!running) ? walkSpeed : runSpeed) * inputDirection.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);       

        if (grounded)
        {
            rb.velocity = transform.forward * (currentSpeed * Time.deltaTime);           
        }
        
        // transform.Translate((transform.forward * (currentSpeed * Time.deltaTime)), Space.World);
             
        // ***** STAMINA CODE ********
        if (running && grounded)
        {
            stamina -= Time.deltaTime;
            //Debug.Log("Im losing Stam!");
            if (stamina <= 0)
            {
                stamina = 0;
                running = false;
                runSpeed = walkSpeed;
               // Debug.Log("cant run anymore");

                if (grounded)playerAnimate.CurrentAnimation = AnimationStates.walking;  //switching to walking animation 
            }
           else {playerAnimate.CurrentAnimation = AnimationStates.running; } //switching to running animation
        }
        else if(stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
    }
  
}

