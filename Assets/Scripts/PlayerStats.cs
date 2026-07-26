using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int Condition = 100; //player health
    public int Progress = 0; //player progress toward end goal

    public Slider ConditionDisplay;
    public Slider ProgressDisplay;
    public bool Sleeping = true; //awake = false
    

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ConditionDisplay.value = Condition;
        ProgressDisplay.value = Progress;
        
    }
}
