using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// ���Գ��򻯿���spine����
/// </summary>
public class ScissorProcedure : Scissor
{

    //����player��Ҫת�Ƶõ��������
    public CinemachineVirtualCamera transformCamera;
    //ת�Ƶ���һ�����������������Ҫ��ʱ��
    public float blendTime;
    protected override void StartCut()
    {
        base.StartCut();
        _aniamator.speed = 1f;
        Debug.Log("speed �ָ�����");
    }

    public override void Cut()
    {

        base.Cut();
        AnimatorStateInfo stateInfo = _aniamator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName("cut"))
        {
            _aniamator.speed = ReadyCutSpeed;
        }
    }

    protected override void AfterDetectAndAttack()
    {
        if (transformCamera != null)
        {
            CameraMgr.GetInstance().SetDefaultBlednTime(blendTime);
            CameraMgr.GetInstance().ChangeCamera(transformCamera, 1);
            CinemachineFramingTransposer transposer = CameraMgr.GetInstance().PlayerVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset = new Vector3(0, 0, 0);


        }
       
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {


    }

}
