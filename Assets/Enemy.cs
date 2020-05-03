using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    GameObject player;
    List<GameObject> shields = new List<GameObject>();
    GameObject[] getShields;

    GameObject[] getParticles;
    List<GameObject> particles = new List<GameObject>();
    ParticleSystem.EmissionModule tempEmissionRate;

    public int hp = 10;
    private bool dying = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        getShields = GameObject.FindGameObjectsWithTag("eShield");
        foreach (var shield in getShields)
        {
            if (Vector3.Distance(this.transform.position, shield.transform.position) < 1.5)
            {
                shield.transform.parent = transform;
                shields.Add(shield);
            }
        }

        getParticles = GameObject.FindGameObjectsWithTag("eParticles");
        foreach (var particle in getParticles)
        {
            if (Vector3.Distance(this.transform.position, particle.transform.position) < 5)
            {
                particle.transform.parent = transform;
                particles.Add(particle);
            }
        }

        //setting particle rate speed
        for (int i = 0; i < particles.Count; i++)
        {
            tempEmissionRate = particles[i].GetComponent<ParticleSystem>().emission;
            tempEmissionRate.rateOverTime = 3;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(var shield in shields)
        {
            try
            {
                shield.transform.RotateAround(transform.position, Vector3.up, 300f * Time.deltaTime);
            }
            catch (MissingReferenceException e)
            {
                //Debug.Log("Error " + e);
            }
        }

        foreach(var particle in particles)
        {
            particle.transform.RotateAround(transform.position, Vector3.up, -600f * Time.deltaTime);
            if (hp < hp / 2 && !dying) {
                //setting particle rate speed when half health
                for (int i = 0; i < particles.Count; i++)
                {
                    tempEmissionRate = particles[i].GetComponent<ParticleSystem>().emission;
                    tempEmissionRate.rateOverTime = 7;
                }

                dying = true;   //stop this loop being called
            }
            //tempEmissionRate = particle.GetComponent<ParticleSystem>().emission;
            //tempEmissionRate.rateOverTime = 10;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
        transform.LookAt(player.transform);
    }


    private void OnParticleCollision(GameObject other)
    {
        hp--;

        if(hp < 1)
        {
            //Detatch from parent & stop emmission 
            foreach (var particle in particles)
            {
                particle.transform.parent = null;
            }
            for (int i = 0; i < particles.Count; i++)
            {
                tempEmissionRate = particles[i].GetComponent<ParticleSystem>().emission;
                tempEmissionRate.rateOverTime = 0;
            }

            Destroy(this.gameObject);
        }
    }

}
