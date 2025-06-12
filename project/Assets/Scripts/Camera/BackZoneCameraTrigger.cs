using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackZoneCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "BZCamera";
        _exitBlednTime = 0.8f;
        base.Awake();
    }
}
