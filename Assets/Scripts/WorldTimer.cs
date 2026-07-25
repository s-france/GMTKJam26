using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class WorldTimer : MonoBehaviour
{
    public static WorldTimer Instance;
    public UnityEvent TickForward;
    public struct Action
    {
        // reference to Action/Event Taken in Timeslot
        string ActionTaken;
        // Is Last in list flag
        bool LastInTimeline;
        // 
    };

    public List<Action> Timeline;
    int CurrentTimeslot = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            TickForward = new UnityEvent();
            TickForward.AddListener(ProcessTick);
        } else
        {
            Destroy(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // If current action receives an Event
            // ProcessTick()
    }

    void ProcessTick()
    {
        // Track Action Taken
        CurrentTimeslot++;
    }
}
