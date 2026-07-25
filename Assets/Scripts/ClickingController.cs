using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClickingController : MonoBehaviour
{
    public static ClickingController Instance;

    [SerializeField] public List<AudioClip> SFXs;
    public AudioClip clickSound;
    private Camera mainCam;
    public bool GameClickType = false; // false == World Click
    public UnityEvent<Vector3> OnGameClick;
    public UnityEvent<Vector3> OnUIClick;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        mainCam = Camera.main;
        OnGameClick = new UnityEvent<Vector3>();
        OnUIClick = new UnityEvent<Vector3>();
        clickSound = SFXs[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(clickSound, transform.position);
            if (GameClickType == false)
            {
                Vector3 screenPos = Input.mousePosition;
                Vector3 worldPos = mainCam.ScreenToWorldPoint(screenPos);
                //Debug.Log("Game Click! " + worldPos.x + " " + worldPos.y);
                OnGameClick?.Invoke(worldPos);
            }
            else
            {
                Vector3 screenPos = Input.mousePosition;
                Vector3 worldPos = mainCam.ScreenToWorldPoint(screenPos);
                //Debug.Log("UI Click! " + worldPos.x + " " + worldPos.y);
                OnUIClick?.Invoke(worldPos);
            }
        }
    }
}
