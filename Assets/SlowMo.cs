using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class SlowMo : MonoBehaviour
{
    ParticleSystem ps;
    Animator slowmo;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        slowmo = GameObject.Find("Player").GetComponent<Animator>();
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

            slowmo.SetBool("slow", true);
            
        }
        else
        {
            Time.timeScale = 0.5f;
            Debug.Log("PC-Trig - Slowed");

            slowmo.SetBool("slow", false);

        }

        //Debug.Log("Inside: " + numInside);
        
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
