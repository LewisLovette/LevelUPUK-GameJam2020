﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutputData : MonoBehaviour
{
    DateTime startTime;
    private TimeSpan totalTime;
    private int totalBullets = 0;
    private int totalHealth;
    private int enemiesKilled;
    private int sceneSwitch = 0;

    bool load2 = false;
    bool load3 = false;
    bool loadEnd = false;

    //bool delayLoad2 = false;
    //bool delayLoad3 = false;
    //bool delayLoadEnd = false;

    //float delay1 = 0;
    //float delay2 = 0;
    //float delay3 = 0;

    public int TotalBullets { get => totalBullets; set => totalBullets = value; }
    public int TotalHealth { get => totalHealth; set => totalHealth = value; }
    public int EnemiesKilled { get => enemiesKilled; set => enemiesKilled = value; }
    public TimeSpan TotalTime { get => totalTime; set => totalTime = value; }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        startTime = DateTime.Now;
    }

    void Update()
    {
        //Debug.Log("Enemies killed: " + EnemiesKilled);
        if (enemiesKilled == 1 && !load2)
        {
            load2 = true;
            //delayLoad2 = true;
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
        else if(enemiesKilled == 3 && !load3)
        {
            load3 = true;
            //delayLoad2 = true;
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
        else if(enemiesKilled == 7 && !loadEnd)
        {
            loadEnd = true;
            //delayLoadEnd = true;
            Debug.Log("SWITCH OD");
            FinishRun();
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }

        //if (delayLoad2)
        //{

        //}


    }

    public void FinishRun()
    {
        totalTime = DateTime.Now.Subtract(startTime);
    }
}
