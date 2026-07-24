using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReceivingClick : MonoBehaviour
{
    private Camera mainCam;
    private UnityEvent receivingClick;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        mainCam.GetComponent<ClickingController>().OnClick.AddListener(CheckIfClicked);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckIfClicked(Vector3 Position)
    {
        
    }
}
