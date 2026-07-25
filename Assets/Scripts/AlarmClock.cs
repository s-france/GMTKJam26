using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmClock : Timer
{
    public GameObject MenuPopUp;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        MenuPopUp.SetActive(true);
        ClickingController.Instance.GameClickType = true;
        //AddTime(1);
    }

    public void GoToSleep()
    {
        Debug.Log("sleeping!");
        int x = Random.Range(5, 11);
        for (int i = x; i == 0; i--)
        {
            SleepTick();
        }
    }

    public void SleepTick()
    {
        // Progress Time By 1
        // Increase Condition By Rand(x)
    }

    public void Snooze()
    {
        int x = Random.Range(1, 3);
        for (int i = x; i == 0; i--)
        {
            SleepTick();
        }
    }
}
