using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eShield : MonoBehaviour
{

    int hp = 100;

    private float damageTime;
    private bool recieveDamage;

    private OutputData data;

    private void Start()
    {
        data = GameObject.Find("Data").GetComponent<OutputData>();
    }

    private void FixedUpdate()
    {
        damageTime += Time.deltaTime;
        //So no double hits
        if (damageTime > 0.1)
        {
            damageTime = 0;
            recieveDamage = true;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (recieveDamage)
        {
            Debug.Log("SHIELD HIT " + this.name);

            this.hp--;

            if (this.hp < 1)
            {
                data.TotalHealth++;
                Destroy(this.gameObject);
            }
        }
    }
}
