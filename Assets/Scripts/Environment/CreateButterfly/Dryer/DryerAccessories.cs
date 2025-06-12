using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryerAccessories : MonoBehaviour
{

    public GameObject effect;
    /// 特效展开的时候要转移到的摄像机
    public CinemachineVirtualCamera GreatSizeCamera;
    ///恢复的时候要转移到的摄像机
    public CinemachineVirtualCamera ResetCamera;
    ///移动到GreatSizeCamera需要的过度时间
    public float BlendTime;


    protected bool resetCamera;
    protected bool _canBeTouch;
    protected Jump _jump;
 
    private void Awake()
    {
        _canBeTouch = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && _canBeTouch)
        {
            Touch touch = collision.GetComponent<Touch>();
            touch.SetTouchIn();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && _canBeTouch)
        {
            if (InputManager.GetInstance().ControlButton.State.CurrentState == InputHelper.ButtonState.ButtonDown)
            {
                DoWhenPlayerTouch(other);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && _canBeTouch)
        {
            Touch touch = collision.GetComponent<Touch>();
            touch.SetTouchOut();
        }
    }



    /// <summary>
    /// 当 player 触碰到自己时候 
    /// </summary>
    /// <param name="collision"></param>
    protected void DoWhenPlayerTouch(Collider2D collision)
    {
        //激活特效
        effect.SetActive(true);
        //添加功能，固定在玩家的右上角
        KeepAtPoint keep = this.gameObject.AddComponent<KeepAtPoint>();
        keep.Target = collision.gameObject;
        keep.SetOffset(new Vector2(2, 2));
        //重置player的touch Animator参数
        Touch touch = collision.GetComponent<Touch>();
        touch.SetTouchOut();


        //切换摄像机
        CameraMgr.GetInstance().ChangeCamera(GreatSizeCamera, BlendTime);

        _canBeTouch = false;

        Invoke("EventTriggerRecover", BlendTime + 1);
    }

    protected void EventTriggerRecover()
    {
        resetCamera = true;
    }

    private void Update()
    {
        if (resetCamera)
        {
            //如果在展示完大纸蝴蝶后按下了左移或右移，恢复摄像机
            //这里线不用 inputManager 是因为不知道为什么获得状态的时候会是空引用，以后有时间再来修复desu
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                GreatSizeCamera.enabled = false;
                ResetCamera.enabled = false;
                ResetCamera.enabled = true;
                resetCamera = false;
            }
        }
    }


}
