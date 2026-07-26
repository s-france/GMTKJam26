using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Timer
{

    public GameObject eatbutton;
    public GameObject cookbutton;
    public bool burnt = false;
    public bool cooking = false;
    public bool ready = false;
    public AudioClip cookingsound;
    public AudioClip eatingsound;

    ///food is cooked from 5-10 ticks left on timer
    /// food is burnt for anything under 5
    /// make a bowl when food is ready
    /// make a bowl with poop when food is burnt
    
    public override void Update()
    {
        if (display != null)
        {
            display.value = time-5;

            if (display.value <= 0)
            {
                display.gameObject.SetActive(false);
            } else
            {
                display.gameObject.SetActive(true);

            }

        }
    }
    
    public override void TickForward()
    {
        if (time > 0){
            ready = false;
            eatbutton.SetActive(false);
            AddTime(-1);
        }

        if(time < 10 && time > 5){
            ready = true;
            FoodReady();
        }

        if(time < 5 && cooking){
            burnt = true;
            ready = true;
        }


    }
    ///attach to eat food button
    /// IDK if this works
    public void eatFood(){
        cooking = false;
        ready = false;

        AudioSource.PlayClipAtPoint(eatingsound, transform.position);
        if(burnt){
            PlayerStats.Instance.Condition -= 5;
        }
        else{
            if (PlayerStats.Instance.Condition < 100)
            {
                PlayerStats.Instance.Condition += 10;
                if (PlayerStats.Instance.Condition > 100)
                {
                    PlayerStats.Instance.Condition = 100;
                }
            }
        }
        eatbutton.SetActive(false);

        time = 0;

        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 
    }

    public void CookFood()
    {
        if (time <= 0 && !cooking)
        {
            AudioSource.PlayClipAtPoint(cookingsound, transform.position);
            cooking = true;
            SetTime(20);
        }


        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 


    }

    public void FoodReady()
    {
        Debug.Log("Food Ready!");
        //cooking = false;
        ready = true;
        eatbutton.SetActive(true);

    }


    public override void OnClick()
    {
        base.OnClick();

        if (ready == true)
        {
            eatbutton.SetActive(true);
        } else
        {
            eatbutton.SetActive(false);

        }
        if(cooking == true){
            cookbutton.SetActive(false);
        }
        else {
            cookbutton.SetActive(true);
        }

    }
}
