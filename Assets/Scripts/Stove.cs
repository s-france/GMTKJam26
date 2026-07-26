using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Timer
{

    public GameObject eatbutton;
    public bool burnt = false;
    public bool cooking = false;
    ///food is cooked from 5-10 ticks left on timer
    /// food is burnt for anything under 5
    /// make a bowl when food is ready
    /// make a bowl with poop when food is burnt
    public override void TickForward()
    {
        if (time > 0){
            eatbutton.SetActive(false);
            AddTime(-1);
        }

        if(time < 10 && time > 5){
            FoodReady();
        }

        if(time < 5){
            burnt = true;
        }


    }
    ///attach to eat food button
    /// IDK if this works
    public void eatFood(){
        cooking = false;
        
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
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 
    }

    public void CookFood()
    {
        if (time <= 0 && !cooking)
        {
            cooking = true;
            SetTime(20);
        }

        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 


    }

    public void FoodReady()
    {
        cooking = false;
        eatbutton.SetActive(true);

    }
}
