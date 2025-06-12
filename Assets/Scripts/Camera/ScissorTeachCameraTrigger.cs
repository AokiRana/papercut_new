using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorTeachCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "ScissorTeachCamera";
        base.Awake();
    }
}
