using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CreateButterflyUpTreeCM3Trigger : CameraTriggerBase
{

    protected override void Awake()
    {
        _VCameraName = "CreateButterflyUpTreeCM3";
        _inBlendTime = 0.5f;
        base.Awake();
    }



}
