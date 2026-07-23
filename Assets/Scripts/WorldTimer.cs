using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class WorldTimer : MonoBehaviour
{
    public static UnityEvent TickForward;
    struct Action
    {
        // reference to Action/Event Taken in Timeslot
        // Is Last in list flag
        // 
    };

    List<Action> Timeline;
    int CurrentTimeslot = 0;
    // Start is called before the first frame update
    void Start()
    {
        TickForward = new UnityEvent();
        TickForward.AddListener(ProcessTick);
    }

    // Update is called once per frame
    void Update()
    {
        // If current action receives an Event
            // ProcessTick()
    }

    void ProcessTick()
    {
        CurrentTimeslot++;
    }
}
