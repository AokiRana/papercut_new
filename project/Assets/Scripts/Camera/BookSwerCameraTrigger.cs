using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSwerCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "BookSwerCamera";
        _inBlendTime = 0.8f;
        base.Awake();
    }
}
