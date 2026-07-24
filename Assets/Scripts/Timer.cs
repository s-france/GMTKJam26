using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TickForward()
    {
        AddTime(-1);
    }

    public void AddTime(int t)
    {
        time += t;

        if(time <=0)
        {
            EndTimer();
        }
    }

    public void SetTime(int t)
    {
        time = t;
    }


    public virtual void EndTimer()
    {
        
    }

}
