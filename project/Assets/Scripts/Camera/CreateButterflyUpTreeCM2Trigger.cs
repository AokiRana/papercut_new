using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButterflyUpTreeCM2Trigger : CameraTriggerBase
{
    protected override void Awake()
    {

        _VCameraName = "CreateButterflyUpTreeCM2";
        _inBlendTime = 0.5f;
        base.Awake();
    }

    protected override void DoWhenTriggerEnter(Collider2D collision)
    {
        base.DoWhenTriggerEnter(collision);

        //������ұ߽��룬blendTime = 1.5fV
        if (collision.gameObject.transform.position.x > cameraTriggerBox.bounds.center.x)
        {
            _inBlendTime = 1.5f;
        }
    }
}
