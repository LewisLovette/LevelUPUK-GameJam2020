using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float hp = 0;
    private float maxHP;
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
    private float damageTime;
    private bool recieveDamage = false;
    float growCD = 0;

    public float barDisplay; //current progress
    public Vector2 pos;
    public Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;

    private OutputData data;

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
        data = GameObject.Find("Data").GetComponent<OutputData>();

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

        maxHP = hp;

        pos = new Vector2(20, 40);
        size = new Vector2(500, 30);
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

        //barDisplay = Time.time * 0.05f;
        //Debug.Log("HP STUFF : " + barDisplay + " : " + (float)(hp / maxHP)*100 + " : " + hp);
        //timer += 1 * Time.deltaTime;
    }


    void FixedUpdate()
    {
        growCD -= 1 * Time.deltaTime;

        if (growAir && growCD <= 0)
        {
            //timer = 0;

            airScale += 0.5f;
            temp.transform.localScale = new Vector3(airScale, airScale, airScale);

            Debug.Log(airScale);

            if (airScale > 20f)
            {
                airScale = 1f;
                Destroy(temp);
                growAir = false;
                growCD = 1f;
            }
        }

        damageTime += 1 * Time.deltaTime;

        //So no double hits
        if (damageTime > 0.1)
        {
            damageTime = 0;
            recieveDamage = true;
        }
    }


    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * (hp / maxHP), size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (recieveDamage)
        {
            hp-=1;
            data.TotalHealth++;

            if (hp < 1)
            {

                particles.transform.parent = null;
                fire.rateOverTime = 0;

                Destroy(this.gameObject);
            }
        }
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

    public void SlowTime()
    {
        Time.timeScale = 0.1f;
        //Debug.Log("TIME SLOWED");
    }

    public void NormalTime()
    {
        Time.timeScale = 1f;
    }
}
