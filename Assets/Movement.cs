﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    private GameObject particles;
    private GameObject shield;
    private GameObject slowmo;
    private ParticleSystem.EmissionModule fire;
    private ControllerControls controller;

    private Vector2 rotate;
    private bool left = false;
    private bool right = false;
    void Awake()
    {
        controller = new ControllerControls();

        controller.Main.Fire.performed += ctx => Shoot();
        controller.Main.Fire.canceled += ctx => ShootStop();

        controller.Main.rLeft.performed += ctx => RotateLeft();
        controller.Main.rRight.performed += ctx => RotateRight();
        controller.Main.rUp.performed += ctx => RotateUp();
        controller.Main.rDown.performed += ctx => RotateDown();

        controller.Main.rLeft.canceled += ctx => RotateStop();
        controller.Main.rRight.canceled += ctx => RotateStop();

    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //parenting objects
        particles = GameObject.Find("Particles");
        particles.transform.parent = transform;

        shield = GameObject.Find("Shield");
        shield.transform.parent = transform;

        slowmo = GameObject.Find("SlowMo");
        slowmo.transform.parent = transform;

        fire = GameObject.Find("Particles").GetComponent<ParticleSystem>().emission;
        fire.rateOverTime = 0;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //if (Input.GetButton("Jump"))
            //{
            //    moveDirection.y = jumpSpeed;
            //}
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                fire.rateOverTime = 0;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        if (left)
        {
            particles.transform.RotateAround(transform.position, Vector3.up, -300f * Time.deltaTime);
            shield.transform.RotateAround(transform.position, Vector3.up, -300f * Time.deltaTime);
            slowmo.transform.RotateAround(transform.position, Vector3.up, -300f * Time.deltaTime);
        }
        else if (right)
        {
            particles.transform.RotateAround(transform.position, Vector3.up, 300f * Time.deltaTime);
            shield.transform.RotateAround(transform.position, Vector3.up, 300f * Time.deltaTime);
            slowmo.transform.RotateAround(transform.position, Vector3.up, 300f * Time.deltaTime);
        }
        
    }

    void Shoot()
    {
        fire.rateOverTime = 10;
    }

    void RotateLeft()
    {
        left = true;
        //particles.transform.RotateAround(transform.position, Vector3.up, 50f);
    }
    void RotateRight()
    {
        right = true;
        //particles.transform.RotateAround(transform.position, Vector3.up, -50f);
    }
    void RotateUp()
    {

    }
    void RotateDown()
    {

    }

    void RotateStop()
    {
        left = false;
        right = false;
    }

    void ShootStop()
    {
        fire.rateOverTime = 0;
    }

    private void OnEnable()
    {
        controller.Main.Enable();
    }

    private void OnDisable()
    {
        controller.Main.Disable();
    }
}
