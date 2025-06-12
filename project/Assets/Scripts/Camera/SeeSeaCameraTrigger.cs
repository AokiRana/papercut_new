using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSeaCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "SeeSeaCamera";
        _inBlendTime = 1f;
        base.Awake();
    }
}
