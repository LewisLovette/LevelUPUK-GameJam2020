using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    List<GameObject> shields = new List<GameObject>();
    GameObject[] getShields;

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

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
        transform.LookAt(player.transform);
    }
}
