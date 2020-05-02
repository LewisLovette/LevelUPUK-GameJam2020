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
    public GameObject airGunPrefab;


    private Vector3 moveDirection = Vector3.zero;

    private GameObject particles;
    private GameObject shield;
    private GameObject slowmo;
    private ParticleSystem.EmissionModule fire;
    private ControllerControls controller;

    private Vector2 rotate;
    private bool left = false;
    private bool right = false;
    private bool growAir = false;

    GameObject temp;
    float airScale = 1f;
    float timer = 0;

    void Awake()
    {
        controller = new ControllerControls();

        controller.Main.Fire.performed += ctx => Shoot();
        controller.Main.Fire.canceled += ctx => ShootStop();

        controller.Main.rLeft.performed += ctx => RotateLeft();
        controller.Main.rRight.performed += ctx => RotateRight();
        controller.Main.AirGun.performed += ctx => AirShot();

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

        if (growAir)
        {
            timer = 0;

            airScale += 0.25f;
            temp.transform.localScale = new Vector3(airScale, airScale, airScale);

            Debug.Log(airScale);

            if(airScale > 20f)
            {
                airScale = 1f;
                Destroy(temp);
                growAir = false;
            }
        }

        timer += 1 * Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Player Hit!");
    }

    void Shoot()
    {
        fire.rateOverTime = 10;
    }

    void AirShot()
    {
        if (!growAir)
        {
            temp = Instantiate(airGunPrefab, transform.position, slowmo.transform.rotation);
            temp.layer = 11;
            growAir = true;
        }
        //temp.transform.LookAt(particles.transform);
        //temp.GetComponent<Rigidbody>().velocity = slowmo.transform.right*10;
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
