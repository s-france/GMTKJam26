using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Timer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void getfood(){

        if (PlayerStats.Instance.Condition < 100)
        {

            WorldTimer.Instance.TickForward.Invoke();
    
            PlayerStats.Instance.Condition += Random.Range(1,6);
            if (PlayerStats.Instance.Condition > 100)
            {
                PlayerStats.Instance.Condition = 100;
            }
        }
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 
    }
}
