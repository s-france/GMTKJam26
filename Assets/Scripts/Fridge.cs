using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Timer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getfood(){

        if (PlayerStats.Instance.Condition < 100)
        {
            for(int i =0; i <3; i++){
            WorldTimer.Instance.TickForward.Invoke();
            }
            PlayerStats.Instance.Condition += 1;
            if (PlayerStats.Instance.Condition > 100)
            {
                PlayerStats.Instance.Condition = 100;
            }
        }
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 
    }
}
