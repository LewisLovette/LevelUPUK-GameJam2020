using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class SlowMo : MonoBehaviour
{
    ParticleSystem ps;
    Animator slowmo;
    CinemachineVirtualCamera zoom;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        slowmo = GameObject.Find("Player").GetComponent<Animator>();
        zoom = GameObject.Find("CM2").GetComponent<CinemachineVirtualCamera>();
    }


    private void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);

        if (numInside > 0)
        {
            Debug.Log("PC-Trig - Slowed");
            Time.timeScale = 0.1f;

            zoom.enabled = true;

            //StartCoroutine("slow");
        }
        else
        {
            Time.timeScale = 1f;

            zoom.enabled = false;

            //Debug.Log("PC-Trig - Normal");

            //StartCoroutine("normal");


        }

        //Debug.Log("Inside: " + numInside);
        
    }

    void slow()
    {
        slowmo.SetBool("slow", true);

    }

    void normal()
    {
        //slowmo.SetBool("slow", false);
    }

    private void OnParticleCollision(GameObject other)
    {
        Time.timeScale = 0.5f;
        Debug.Log("PC-Col - Slowed");
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0.5f;
        Debug.Log("Slowed");
    }

    private void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1f;
        Debug.Log("Normal");
    }

}
