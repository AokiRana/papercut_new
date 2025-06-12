using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonJump : MonoBehaviour
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
            InputManager.GetInstance().JumpButton.State.ChangeState(InputHelper.ButtonState.ButtonDown);
            Debug.Log(" jump °´ÏÂ");
        });

        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) =>
        {
            InputManager.GetInstance().JumpButton.State.ChangeState(InputHelper.ButtonState.ButtonUp);
            Debug.Log(" jump Ì§Æð");
        });

        trigger.triggers.Add(entry);
    }
}
