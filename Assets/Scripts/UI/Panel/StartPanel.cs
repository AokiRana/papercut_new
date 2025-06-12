using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public float fadeoutTime;
    public Image mask;

    public PanelButton currentButton;
    public PanelButton preButton;

    protected bool canNavigate = true;
    /// <summary>
    /// 是否已经按下了开始游戏按钮
    /// </summary>
    protected bool isPressStartGame;
    ///text的事件列表
    protected Dictionary<string, UnityAction> eventList = new Dictionary<string, UnityAction>();



    protected override void Awake()
    {
        base.Awake();
        isPressStartGame = false;
        canNavigate = true;
        currentButton = GameObject.Find("txtStart").GetComponent<PanelButton>();
        preButton = null;
        //StartCoroutine(FadeIn());
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

        if (!canNavigate)
        {
            return;
        }

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

    /// <summary>
    /// 在awake的时候进行事件注册
    /// </summary>
    protected override void TextOnClick()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            switch (textList[i].gameObject.name)
            {
                case "txtStart":
                    eventList.Add("txtStart", TxtStartEvent);
                    break;

                case "txtSet":
                    eventList.Add("txtSet", TxtSetEvent);
                    break;

                case "txtExit":
                    eventList.Add("txtExit", TxtExitEvent);
                    break;
            }
        }
    }


    public void TxtStartEvent()
    {
        if (!isPressStartGame)
        {
            Debug.Log("start game");
            isPressStartGame = true;
            canNavigate = false;
            StartCoroutine(FadeOut());
        }
    }

    protected void TxtSetEvent()
    {
        Debug.Log("txtSet");
        UIMgr.GetInstance().HidePanel<StartPanel>();
        UIMgr.GetInstance().ShowPanel<SetPanel>();
    }

    protected void TxtExitEvent()
    {
        Debug.Log("txtExit");
        //在编辑模式下没有用，正式打包出去后才有用
        Application.Quit();
    }


    protected IEnumerator FadeIn()
    {
        float t = 0;
        while (t <= fadeoutTime)
        {

            float newAplha = Mathf.Lerp(1, 0, t / fadeoutTime);
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, newAplha);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 0);
    }

    /// <summary>
    /// 点击 开始游戏 时的淡化
    /// </summary>
    protected IEnumerator FadeOut()
    {
        float t = 0;
        while (t <= fadeoutTime)
        {

            float newAplha = Mathf.Lerp(0, 1, t / fadeoutTime);
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, newAplha);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        UIMgr.GetInstance().HidePanel<BKPanel>();

        mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 1);

        UIMgr.GetInstance().HidePanel<StartPanel>();


        AfterFade();
    }

    protected void AfterFade()
    {

        BKMusicMgr.GetInstance().StopBK();
        SceneMgr.GetInstance().LoadSceneAsync("LoadingScene", () =>
        {
           
            SceneMgr.GetInstance().LoadSceneAsync("testScene", () =>
            {
                UIMgr.GetInstance().Clear();
            });
    

        },1.5f);

        UIMgr.GetInstance().HidePanel<BKPanel>();
        UIMgr.GetInstance().HidePanel<StartPanel>();
    }

}
