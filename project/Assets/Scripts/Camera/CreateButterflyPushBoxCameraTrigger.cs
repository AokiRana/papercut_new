using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButterflyPushBoxCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "CreateButterflyPushBoxCamera";
        _inBlendTime = 1;
        base.Awake();
        
    }
}
