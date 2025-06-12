using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileTouch : MonoBehaviour
{


    public Button btnLeft;
    public Button btnRight;
    protected EventTrigger trigger;
 
    
    void Start()
    {
        trigger = GetComponent<EventTrigger>();

        btnLeft.onClick.AddListener(() =>
        {
            InputManager.GetInstance().SetMovementMobile(-1, 0);
            Debug.Log("left 按下 速度为" + InputManager.GetInstance().PrimaryMovement.x);
          
        });

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) =>
        {
            InputManager.GetInstance().SetMovementMobile(0, 0);
            Debug.Log("left 抬起");
        });

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
