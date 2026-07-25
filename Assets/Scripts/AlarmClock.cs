using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AlarmClock : Timer
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnClick()
    {
        MenuPopUp.SetActive(true);
        ClickingController.Instance.GameClickType = true;
        //AddTime(1);
    }

    public void GoToSleep()
    {
        ActOfSleeping(5, 11);
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick();
    }

    public void SleepTick()
    {
        // Progress Time By 1
        WorldTimer.Instance.TickForward.Invoke();

        // Increase Condition By Rand(x)
    }

    public void Snooze()
    {
        ActOfSleeping(1, 3);
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick();
    }

    private void ActOfSleeping(int xTimeS, int xTimeE)
    {
        PlayerStats.Instance.Sleeping = true;

        Debug.Log("SLEEPING!");
        int x = Random.Range(xTimeS, xTimeE);
        int y = Random.Range(1, 6);
        for (int i = 0; i<x; i++)
        {
            if (PlayerStats.Instance.Condition < 100)
            {
                PlayerStats.Instance.Condition += y;
                if (PlayerStats.Instance.Condition > 100)
                {
                    PlayerStats.Instance.Condition = 100;
                }
            }
            SleepTick();
        }
        PlayerStats.Instance.Sleeping = false;

    }
}
