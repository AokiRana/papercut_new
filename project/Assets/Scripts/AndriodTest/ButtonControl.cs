using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonControl : MonoBehaviour
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
            InputManager.GetInstance().ControlButton.State.ChangeState(InputHelper.ButtonState.ButtonDown);
            Debug.Log(" control °´ÏÂ");
        });

        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) =>
        {
            InputManager.GetInstance().ControlButton.State.ChangeState(InputHelper.ButtonState.ButtonUp);
            Debug.Log(" control Ì§Æð");
        });

        trigger.triggers.Add(entry);
    }
}
