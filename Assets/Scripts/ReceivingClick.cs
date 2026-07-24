using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReceivingClick : MonoBehaviour
{
    private Collider2D tileCollider;
    private Camera mainCam;

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
        
        mainCam.GetComponent<ClickingController>().OnClick.AddListener(this.CheckIfClicked);
    }
    public void CheckIfClicked(Vector3 Position)
    {
        Debug.Log("click");
        tileCollider = GetComponent<Collider2D>();
        if (tileCollider.OverlapPoint(Position))
        {
            Debug.Log("True");
        }
        ;
    }
}
