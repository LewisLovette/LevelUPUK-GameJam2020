using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eShield : MonoBehaviour
{

    int hp = 1;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("SHIELD HIT " +this.name);

        this.hp--;

        if(this.hp < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
