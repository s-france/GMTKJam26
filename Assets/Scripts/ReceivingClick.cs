using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ReceivingClick : MonoBehaviour
{
    public bool TypeReceiving = false;
    private Collider2D tileCollider;
    private Camera mainCam;

    public UnityEvent OnClick;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init",.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    { 
        mainCam = Camera.main;
        if (TypeReceiving == false)
        {
            mainCam.GetComponent<ClickingController>().OnGameClick.AddListener(this.CheckIfClicked);
        }
        else
        {
            mainCam.GetComponent<ClickingController>().OnUIClick.AddListener(this.CheckIfClicked);
        }
    }
    public void CheckIfClicked(Vector3 Position)
    {
        //Debug.Log("click");
        tileCollider = GetComponent<Collider2D>();
        if (tileCollider.OverlapPoint(Position))
        {
            Debug.Log("clicked!");
            SendMessage("OnClick", null, SendMessageOptions.DontRequireReceiver);
            OnClick.Invoke();
        }
        
    }
}
