using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClickingController : MonoBehaviour
{
    private Camera mainCam;
    public  UnityEvent<Vector3> OnClick;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        OnClick = new UnityEvent<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Left mouse button clicked!");
            Vector3 screenPos = Input.mousePosition;
            Vector3 worldPos = mainCam.ScreenToWorldPoint(screenPos);
            Debug.Log("Left mouse button clicked! " + worldPos.x + " " + worldPos.y);
            OnClick?.Invoke(worldPos);
        }
    }
}
