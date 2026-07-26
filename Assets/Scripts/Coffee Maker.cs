using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoffeeMaker : Timer
{
    public GameObject DrinkButton;
    public GameObject MakeButton;
    public bool Ready = false;
    public bool Brewing = false;
    public bool Cold = false;
    public AudioClip BrewingSound;
    public GameObject coffeealert;
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

        if (display.value <= 0)
        {
            display.gameObject.SetActive(false);
        } else
        {
            display.gameObject.SetActive(true);

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
            coffeealert.SetActive(true);
            CoffeeReady();
        }

        if (time < 5 && Brewing)
        {
            Cold = true;
            Ready = true;
        }

        if (PlayerStats.Instance.QuirkedUpTimer == 0)
        {
            PlayerStats.Instance.QuirkedUp = false;
        }

        if (PlayerStats.Instance.QuirkedUp)
        {
            PlayerStats.Instance.QuirkedUpTimer -= 1;
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
        PlayerStats.Instance.QuirkedUp = true;
        PlayerStats.Instance.QuirkedUpTimer = 3;
        DrinkButton.SetActive(false);
        coffeealert.SetActive(false);

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

    }
}

