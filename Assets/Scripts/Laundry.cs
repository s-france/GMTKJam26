using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : Timer
{

    public int dirtyLaundry = 0;

   

    public override void TickForward()
    {
        //running a load
        if(time >0)
        {
            AddTime(-1);

        } else //dirty laundry
        {
            dirtyLaundry++;

            //harm the player based on how much laundry
            if (dirtyLaundry >= 5)
            {
                PlayerStats.Instance.Condition -= (dirtyLaundry-4) * 4;
            }
        }

    }

    public void StartLaundry()
    {
        //set laundry machine timer
        SetTime(dirtyLaundry + 6);

        //set dirty laundry to 0
        dirtyLaundry = 0;
    }




}
