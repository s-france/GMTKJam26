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
        }

    }

    public void StartLaundry()
    {
        //set laundry machine timer
        SetTime(5);

        //set dirty laundry to 0
        dirtyLaundry = 0;


    }




}
