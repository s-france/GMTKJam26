using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        ClickingController.Instance.GameClickType = false;
        transform.root.gameObject.SetActive(false);
    }
    
}
