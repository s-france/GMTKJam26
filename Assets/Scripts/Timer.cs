using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider display;
    public GameObject MenuPopUp;

    public int time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (display != null)
        {
            display.value = time;

        }
    }

    public virtual void TickForward()
    {
        AddTime(-1);
    }

    public void AddTime(int t)
    {
        time += t;

        if(time <=0)
        {
            time = 0;
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


    public virtual void OnClick()
    {
        MenuPopUp.SetActive(true);
        ClickingController.Instance.GameClickType = true;
        //AddTime(1);
    }


}
