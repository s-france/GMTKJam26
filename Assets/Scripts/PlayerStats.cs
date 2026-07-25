using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int Condition; //player health
    public int Progress; //player progress toward end goal

    public Slider ConditionDisplay;
    public Slider ProgressDisplay;
    

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
