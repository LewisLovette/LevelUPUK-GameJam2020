using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetData : MonoBehaviour
{

    private OutputData data;

    private TextMeshProUGUI timeUI;
    private TextMeshProUGUI hpUI;
    private TextMeshProUGUI enemiesUI;
    private TextMeshProUGUI bulletsUI;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data").GetComponent<OutputData>();

        timeUI = GameObject.Find("setTime").GetComponent<TextMeshProUGUI>();
        hpUI = GameObject.Find("setHP").GetComponent<TextMeshProUGUI>();
        enemiesUI = GameObject.Find("setEnemies").GetComponent<TextMeshProUGUI>();
        bulletsUI = GameObject.Find("setBullets").GetComponent<TextMeshProUGUI>();


        timeUI.text = data.TotalTime.ToString();
        hpUI.text = data.TotalHealth.ToString();
        enemiesUI.text = data.EnemiesKilled.ToString();
        bulletsUI.text = data.TotalBullets.ToString();

    }

}
