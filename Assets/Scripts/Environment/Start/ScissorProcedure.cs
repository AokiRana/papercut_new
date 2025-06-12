using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// 可以程序化控制spine动画
/// </summary>
public class ScissorProcedure : Scissor
{

    //剪中player后要转移得到的摄像机
    public CinemachineVirtualCamera transformCamera;
    //转移到上一个变量的摄像机所需要的时间
    public float blendTime;
    protected override void StartCut()
    {
        base.StartCut();
        _aniamator.speed = 1f;
        Debug.Log("speed 恢复正常");
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
