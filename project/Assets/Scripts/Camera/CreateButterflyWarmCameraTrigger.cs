using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButterflyWarmCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "CreateButterflyWarmCamera";
        _inBlendTime = 1f;
        _exitBlednTime = 0.9f;
        base.Awake();
    }
}
