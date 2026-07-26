using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : Timer
{
    public int dirtyLaundry = 0;

    public bool loaded = false;
    public bool done = false;

    public GameObject LaundryPile;
    public GameObject Basket;

    public AudioClip StartSound;
    public AudioClip EndSound;

    public GameObject WashButton;
    public GameObject EmptyButton;

    void Start()
    {
        Invoke("Init", .1f);
    }

    void Init()
    {
        StartSound = ClickingController.Instance.SFXs[4];
        EndSound = ClickingController.Instance.SFXs[5];
    }

    public override void TickForward()
    {
        AddTime(-1);

        //running a load
        if (time > 0)
        {
            loaded = true;
            done = false;
            
        } else if (loaded)
        {
            time = 0;
            done = true;
        } else
        {
            time = 0;
            done = false;
        }
       
        
        if (loaded)
        {
            //PlayerStats.Instance.Condition -= 2;
            if (done && !PlayerStats.Instance.Sleeping)
            {
                dirtyLaundry++;
                //harm the player based on how much laundry
                if (dirtyLaundry >= 5)
                {
                    PlayerStats.Instance.Condition -= (dirtyLaundry - 4) * 4;
                }
            }

        }
        else if (!PlayerStats.Instance.Sleeping) //dirty laundry
        {
            //Debug.Log("dirty laundry ++");
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

        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 
    }

    public void RemoveLaundry()
    {
        AudioSource.PlayClipAtPoint(EndSound, transform.position);
        if (loaded)
        {
            loaded = false;
            time = 0;
        }

        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 
        
    }

    public override void OnClick()
    {
        MenuPopUp.SetActive(true);

        if (!loaded && dirtyLaundry >= 5)
        {
            WashButton.SetActive(true);
        } else
        {
            WashButton.SetActive(false);
        }

        if(loaded && time <=0)
        {
            EmptyButton.SetActive(true);

        } else
        {
            EmptyButton.SetActive(false);
        }




        ClickingController.Instance.GameClickType = true;
        //AddTime(1);
    }




}
