using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoControl : MonoBehaviour
{
    GameObject[] ps;
    List<SlowMo> checkSlow = new List<SlowMo>();
    CinemachineVirtualCamera zoom;
    int canSlow;

    // Start is called before the first frame update
    void Start()
    {
        zoom = GameObject.Find("CM2").GetComponent<CinemachineVirtualCamera>();
        ps = GameObject.FindGameObjectsWithTag("particles");
        foreach(var system in ps)
        {
            //Debug.Log(system.name);
            checkSlow.Add(system.GetComponent<SlowMo>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        foreach(var slowmo in checkSlow)
        {
            if (slowmo.slowCondition)
            {
                canSlow++;
            }
        }

        if(canSlow > 0)
        {
            Time.timeScale = 0.15f;
            zoom.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            zoom.enabled = false;
        }

        canSlow = 0;
        


    }
}
