using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButterflySubSceneDownCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "CBSubSceneDownCamera";
        _inBlendTime = 1f;
        base.Awake();
    }
}
