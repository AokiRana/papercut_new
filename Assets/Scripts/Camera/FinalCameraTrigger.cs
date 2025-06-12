using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "FinalCamera";
        _inBlendTime = 0.8f;
        base.Awake();
    }
}
