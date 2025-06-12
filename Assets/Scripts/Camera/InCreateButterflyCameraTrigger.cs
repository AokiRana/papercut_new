using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCreateButterflyCameraTrigger : CameraTriggerBase
{

    protected override void Awake()
    {
        _VCameraName = "InCreateButterflyCamera";
        _inBlendTime = 1;
        _exitBlednTime = 0.9f;
        base.Awake();
    }
}
