using System.Collections;
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
    private ParticleSystem.EmissionModule fire;
    private ControllerControls controller;

    //myGameObject.transform.localPosition = wallGameObject.GetComponent<PositionReferences>().GetNextPosition();

    void Awake()
    {
        controller = new ControllerControls();

        controller.Main.Fire.performed += ctx => Shoot();
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        particles = GameObject.Find("Particles");
        particles.transform.parent = transform;
        fire = GameObject.Find("Particles").GetComponent<ParticleSystem>().emission;
        fire.rateOverTime = 0;
    }

    void FixedUpdate()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                fire.rateOverTime = 0;
            }
            else
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
    }

    void Shoot()
    {
        fire.rateOverTime = 10;
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
