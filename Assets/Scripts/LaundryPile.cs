using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryPile : MonoBehaviour
{
    Laundry laundry;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        laundry = FindFirstObjectByType<Laundry>();

        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(laundry.dirtyLaundry >= 5)
        {
            sr.enabled = true;
        } else
        {
            sr.enabled = false;
        }
        
        
    }
}
