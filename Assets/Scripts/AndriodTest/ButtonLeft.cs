using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonLeft : MonoBehaviour
{
    public Button btn;
    public EventTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) =>
        {
            InputManager.GetInstance().SetMovementMobile(-1, 0);
            Debug.Log(" left 按下  速度" + InputManager.GetInstance().PrimaryMovement.x);
        });

        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) =>
        {
            InputManager.GetInstance().SetMovementMobile(0, 0);
            Debug.Log(" right 抬起 速度" + InputManager.GetInstance().PrimaryMovement.x);
        });

        trigger.triggers.Add(entry);
    }


}
