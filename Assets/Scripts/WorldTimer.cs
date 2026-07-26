using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WorldTimer : MonoBehaviour
{
    public bool GameStarted = false;
    public bool GameOver = false;

    public GameObject StartMenu;
    public GameObject EndMenu;


    public int EndTime;

    public static WorldTimer Instance;
    public UnityEvent TickForward;
    /*
    public struct Action
    {
        // reference to Action/Event Taken in Timeslot
        string ActionTaken;
        // Is Last in list flag
        bool LastInTimeline;
        // 
    };
    */

    //public List<Action> Timeline;
    public int CurrentTimeslot = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //TickForward = new UnityEvent();
            //TickForward.AddListener(ProcessTick);
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

    public void ProcessTick()
    {
        Debug.Log("world tick!");

        // Track Action Taken
        CurrentTimeslot++;

        PlayerStats.Instance.Condition -= 3;

        //check for endgame state
        if(CurrentTimeslot >= EndTime || PlayerStats.Instance.Condition <= 0 || PlayerStats.Instance.Progress >=100)
        {
            //end game...
            EndGame();

        }

    }



    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndGame()
    {
        if (PlayerStats.Instance.Condition > 0 && PlayerStats.Instance.Progress >= 100)
        {
            //win
            SceneManager.LoadScene("WinScene");

        } else
        {
            //lose
            SceneManager.LoadScene("LoseScene");

        }
    }
}
