using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : Timer
{
    public bool Ready;
    public bool Brewing;
    public AudioClip BrewingSound;
    // Start is called before the first frame update
    void Start()
    {
        BrewingSound = ClickingController.Instance.SFXs[9];
        Ready = false;
        Brewing = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeCoffee()
    {
        if (Ready == false)
        {
            AudioSource.PlayClipAtPoint(BrewingSound, transform.position);
            Brewing = true;
            WorldTimer.Instance.TickForward.Invoke();
            SetTime(2);
        }
    }
}

