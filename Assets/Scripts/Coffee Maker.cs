using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : Timer
{
    public GameObject DrinkButton;
    public GameObject MakeButton;
    public bool Ready = false;
    public bool Brewing = false;
    public bool Cold = false;
    public AudioClip BrewingSound;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init", .1f);
        
    }

    void Init()
    {
        BrewingSound = ClickingController.Instance.SFXs[9];
    }

    public override void Update()
    {
        if (display != null)
        {
            display.value = time - 5;
        }
    }

    public override void TickForward()
    {
        if (time > 0)
        {
            Ready = false;
            DrinkButton.SetActive(false);
            AddTime(-1);
        }

        if (time < 8 && time > 5)
        {
            Ready = true;
            CoffeeReady();
        }

        if (time < 5 && Brewing)
        {
            Cold = true;
            Ready = true;
        }
    }

    public void DrinkCoffee()
    {
        Brewing = false;
        Ready = false;

        if (Cold)
        {
            PlayerStats.Instance.Condition -= 8;
        }
        else
        {
            PlayerStats.Instance.Condition -= 5;
        }
        DrinkButton.SetActive(false);

        time = 0;
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick();
    }

    public override void OnClick()
    {
        base.OnClick();

        if (Ready == true)
        {
            DrinkButton.SetActive(true);
        }
        else
        {
            DrinkButton.SetActive(false);

        }
    }

    public void MakeCoffee()
    {
        AudioSource.PlayClipAtPoint(BrewingSound, transform.position);
        if (time <= 0 && !Brewing)
        {
            Brewing = true;
            SetTime(10);
        }
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick(); 


    }

    public void CoffeeReady()
    {
        Debug.Log("Coffee Ready!");
        //cooking = false;
        Ready = true;
        DrinkButton.SetActive(true);
        MakeButton.SetActive(false);

    }
}

