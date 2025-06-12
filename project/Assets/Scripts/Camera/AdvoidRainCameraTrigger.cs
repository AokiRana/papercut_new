using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvoidRainCameraTrigger : CameraTriggerBase
{
    protected override void Awake()
    {
        _VCameraName = "AdvoidRainCamera";
        _inBlendTime = 2f;
        _exitBlednTime = 1.5f;
        base.Awake();
    }
    protected override void DoWhenTriggerEnter(Collider2D collision)
    {
        base.DoWhenTriggerEnter(collision);
        Debug.Log("player½øÈë" + "AdvoidRainCamera");
    }
}
