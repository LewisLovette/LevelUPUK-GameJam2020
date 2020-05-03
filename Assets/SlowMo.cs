using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlowMo : MonoBehaviour
{
    ParticleSystem ps;
    Movement player;
    CinemachineVirtualCamera zoom;
    // Start is called before the first frame update

    public bool slowCondition = false;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        zoom = GameObject.Find("CM2").GetComponent<CinemachineVirtualCamera>();
    }


    private void OnParticleTrigger()
    {

        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);

        if (numInside > 0)
        {
            //Debug.Log("PC-Trig - Slowed");
            slowCondition = true;
            //player.SlowTime();

            //zoom.enabled = true;

            //StartCoroutine("slow");
        }
        else
        {
            //player.NormalTime();
            slowCondition = false;
            //zoom.enabled = false;

            //Debug.Log("PC-Trig - Normal");

            //StartCoroutine("normal");


        }

        //Debug.Log("Inside: " + numInside);
        
    }

    void slow()
    {
        //slowmo.SetBool("slow", true);

    }

    void normal()
    {
        //slowmo.SetBool("slow", false);
    }

}
