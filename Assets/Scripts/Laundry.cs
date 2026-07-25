using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : Timer
{
    public int dirtyLaundry = 0;

    public bool loaded = false;

    public AudioClip StartSound;
    public AudioClip EndSound;

    void Start()
    {
        StartSound = ClickingController.Instance.SFXs[4];
        EndSound = ClickingController.Instance.SFXs[5];
    }
    public override void TickForward()
    {
        //running a load
        if (time > 0)
        {
            AddTime(-1);

        }
        else if (loaded)
        {
            PlayerStats.Instance.Condition -= 2;
        }
        else if (!PlayerStats.Instance.Sleeping) //dirty laundry
        {

            dirtyLaundry++;

            //harm the player based on how much laundry
            if (dirtyLaundry >= 5)
            {
                PlayerStats.Instance.Condition -= (dirtyLaundry - 4) * 4;
            }
        }

    }

    public void StartLaundry()
    {
        //set laundry machine timer
        AudioSource.PlayClipAtPoint(StartSound, transform.position);
        SetTime(dirtyLaundry + 6);
        loaded = true;

        //set dirty laundry to 0
        dirtyLaundry = 0;
    }

    public void RemoveLaundry()
    {
        AudioSource.PlayClipAtPoint(EndSound, transform.position);
        if (loaded)
        {
            loaded = false;
            time = 0;
        }
        
    }




}
