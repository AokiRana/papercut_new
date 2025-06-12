using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicPanel : BasePanel
{

    public PanelButton currentButton;
    public PanelButton preButton;
    public Slider sliderVolumn;

    protected Dictionary<string, UnityAction> eventList = new Dictionary<string, UnityAction>();

    protected override void Awake()
    {
        base.Awake();
        //FindChildrenControls<Slider>();

        //currentButton = GameObject.Find("txtMusic").GetComponent<PanelButton>();
        preButton = null;
        sliderVolumn.value = (float)PlayerPrefs.GetInt("GlobalVolum") / 10;
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
        SetVolumn();

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

                eventList[eventName]?.Invoke();
            }

        }
    }


    protected void SetVolumn()
    {

        if (currentButton == null)
        {
            return;
        }
        if (currentButton.name.Equals("txtMusic"))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                MusicVolumnMgr.GetInstance().DeleteVolumn();

                sliderVolumn.value = (float)MusicVolumnMgr.GetInstance().VolumnValue / 10;

                BKMusicMgr.GetInstance().SetVolumn();

            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                MusicVolumnMgr.GetInstance().AddVolumn();

                sliderVolumn.value = (float)MusicVolumnMgr.GetInstance().VolumnValue / 10;

                BKMusicMgr.GetInstance().SetVolumn();
            }

        }
      
    }


    protected override void TextOnClick()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            switch (textList[i].gameObject.name)
            {
                case "txtBack":

                    eventList.Add("txtBack", TxtBackEvent);
                    break;
                
            }
        }
    }

    protected void TxtBackEvent()
    {
        Debug.Log("txtBack");
        PlayerPrefs.SetInt("GlobalVolum", MusicVolumnMgr.GetInstance().VolumnValue);
        UIMgr.GetInstance().ShowPanel<SetPanel>();
        UIMgr.GetInstance().HidePanel<MusicPanel>();
    }




    protected override void OnValueChange(string name, float value)
    {
        switch (name)
        {
            case "SliderMainVolume":
               
                break;
            case "SliderBKVolume":
              
                break;
            case "SliderSoundVolume":
               
                break;
        }
    }
}
