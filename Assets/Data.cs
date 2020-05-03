using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    DateTime startTime;
    TimeSpan totalTime;
    private int totalBullets;
    private int totalHealth;
    private int enemiesKilled;
    private int sceneSwitch = 0;
    public int TotalBullets { get => totalBullets; set => totalBullets = value; }
    public int TotalHealth { get => totalHealth; set => totalHealth = value; }
    public int EnemiesKilled { get => enemiesKilled; set => enemiesKilled = value; }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        startTime = DateTime.Now;
    }
    void SwitchScene()
    {
        if (sceneSwitch == 0)   //to level 2
        {
            sceneSwitch++;
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }
        else if (sceneSwitch == 1)  //to level 3
        {
            sceneSwitch++;
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
        else if(sceneSwitch == 2)   //to end screen
        {
            sceneSwitch++;
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }

    }

    void FinishRun()
    {
        totalTime = DateTime.Now.Subtract(startTime);
    }
}
