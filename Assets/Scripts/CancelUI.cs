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

    public void OnClick()
    {
        ClickingController.Instance.GameClickType = false;
        transform.root.GetChild(0).gameObject.SetActive(false);
    }
    
}
