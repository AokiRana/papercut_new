using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ٿ�TransferScissor ��Handle
public class TransferScissorHandle : HandleBase
{
    //��ʾҪ�ٿص� TransferScissor
    public Scissor transferScissor;

    protected string HandleOnAnimatorParameter = "TurnOn";
    protected string HandleOffAnimatorParameter = "TurnOff";

    protected override void TurnOn()
    {
        Debug.Log("ScissorHandle On");
        transferScissor.Cut();
    }

    protected override void TurnOff()
    {
        Debug.Log("ScissorHandle off");
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
