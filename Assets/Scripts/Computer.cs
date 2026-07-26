using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Timer
{
    public AudioClip TypingSound;
    // Start is called before the first frame update
    void Start()
    {
        TypingSound = ClickingController.Instance.SFXs[11];
    }

    public void DoWork()
    {
        AudioSource.PlayClipAtPoint(TypingSound, transform.position);
        WorldTimer.Instance.TickForward.Invoke();
        PlayerStats.Instance.Progress += Random.Range(1, 5);
        CancelUI cancel = GetComponentInChildren<CancelUI>();
        cancel.OnClick();
    }
    
}
