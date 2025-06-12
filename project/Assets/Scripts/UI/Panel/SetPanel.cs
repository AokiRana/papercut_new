using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SetPanel : BasePanel
{


    public PanelButton currentButton;
    public PanelButton preButton;
    protected Dictionary<string, UnityAction> eventList = new Dictionary<string, UnityAction>();


    protected override void Awake()
    {
        base.Awake();
        //currentButton = GameObject.Find("txtMusic").GetComponent<PanelButton>();
        preButton = null;
    }

    public override void ShowMe()
    {
        base.ShowMe();
    }

    public override void HideMe()
    {
        base.HideMe();
    }


    private void Update()
    {
        Navigate();
        TriggerEvent();
    }


    protected void Navigate()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            preButton = currentButton;
            if (preButton != null)
            {
                preButton.ExitChoose();
            }
            currentButton.UpButton.Choose();
            currentButton = currentButton.UpButton;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            preButton = currentButton;
            if (preButton != null)
            {
                preButton.ExitChoose();
            }
            currentButton.DownButton.Choose();
            currentButton = currentButton.DownButton;
        }
    }


    protected void TriggerEvent()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentButton != null)
            {
                string eventName = currentButton.gameObject.name;
                eventList[eventName].Invoke();
            }

        }
    }

    protected override void TextOnClick()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            switch (textList[i].gameObject.name)
            {
                case "txtMusic":
                    eventList.Add("txtMusic", TxtMusicEvent);
                    break;
               
                case "txtExit":
                    eventList.Add("txtExit", TxtExitEvent);
                    break;
            }
        }
    }

    protected void TxtMusicEvent()
    {
        UIMgr.GetInstance().ShowPanel<MusicPanel>();
        UIMgr.GetInstance().HidePanel<SetPanel>();
    }

    protected void TxtExitEvent()
    {
        UIMgr.GetInstance().ShowPanel<StartPanel>();
        UIMgr.GetInstance().HidePanel<SetPanel>();
    }


}
