using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandle : HandleBase
{
    public PathMovement pathMovement;

    //表示要操控的 TransferScissor
    public AutoRotate bigWheel;
    public float bigWheelSpeed;

    public AutoRotate smallWheel;
    public float smallWheelSpeed;


    protected string HandleOnAnimatorParameter = "TurnOn";
    protected string HandleOffAnimatorParameter = "TurnOff";


    protected override void Start()
    {
        base.Start();
        //pathMovement.SetReachPointCallBack(() =>
        //{
        //    SetWheelRotate(false);
        //    ChangeWheelRotateDir();
        //});
    }


    /// <summary>
    /// 使wheel停下来
    /// </summary>
    protected void SetWheelRotate(bool rotate)
    {
        bigWheel.SetRotate(rotate);
        smallWheel.SetRotate(rotate);
    }

    /// <summary>
    /// 是wheel方向改变
    /// </summary>
    protected void ChangeWheelRotateDir()
    {
        bigWheelSpeed = -bigWheelSpeed;
        smallWheelSpeed = -smallWheelSpeed;

        bigWheel.SetSpeed(bigWheelSpeed);
        smallWheel.SetSpeed(smallWheelSpeed);
    }

    protected override void TurnOn()
    {
        if (!pathMovement.CanMove)
        {
            pathMovement.CanMove = true;
            pathMovement.isConditionMove = true;

            //如果轮子没有旋转，就旋转他们
            if (!bigWheel.IsRoate || !smallWheel.IsRoate)
            {
                SetWheelRotate(true);
            }
        }
    }



    protected override void TurnOff()
    {

    }

    protected override void TurnOnChangeAnimatorParameter()
    {
        _animator.SetBool(HandleOnAnimatorParameter, true);
        _animator.SetBool(HandleOffAnimatorParameter, false);
    }

    protected override void TurnOffChangeAnimatorParameter()
    {
        _animator.SetBool(HandleOffAnimatorParameter, true);
        _animator.SetBool(HandleOnAnimatorParameter, false);
    }

}
