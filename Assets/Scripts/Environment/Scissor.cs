using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;



/// <summary>
/// Scissor 的基类
/// </summary>
public class Scissor : MonoBehaviour
{

    //准备cut的速度
    public float ReadyCutSpeed;
    public Transform effect;
    public Transform transferPoint; 

    ///控制剪刀的animator组件
    protected Animator _aniamator;
    ///这个特性可以只能的显现出对应animator含有的spine event
    [SpineEvent]
    protected string eventName;

    ///检测有没有 "剪到" MeI 的box，在scene中调整box就会对应的调整 overlap 和 gizmos
    public BoxCollider2D detectBox;
    protected Vector2 center;
    protected Vector2 radius;

    protected virtual void Start()
    {
        _aniamator = GetComponentInParent<Animator>();
        center = detectBox.bounds.center;
        radius = new Vector2(detectBox.bounds.size.x, detectBox.bounds.size.y);
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Cut();
        }
    }

    /// <summary>
    /// 重置 Cut 的Animator参数 ,spine 动画事件
    /// </summary>
    protected virtual void CutOver()
    {
        _aniamator.SetBool("isCut", false);
        Debug.Log("iscut is false");
    }

    /// <summary>
    /// 重置 twine 的Animator参数，spine 动画事件
    /// </summary>
    protected virtual void TwineOver()
    {
        _aniamator.SetBool("isTwine", false);
    }

    /// <summary>
    /// cut开始时 的Animator参数,spine 动画事件
    /// </summary>
    protected virtual void StartCut()
    {
        
    }

    /// <summary>
    /// 提供外部调用，使剪刀开剪
    /// </summary>
    public virtual void Cut()
    {
        AnimatorStateInfo stateInfo = _aniamator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("cut"))
        {
            return;
        }

        _aniamator.SetBool("isCut", true);
    }


    /// <summary>
    /// 剪刀剪中的那一瞬间触发的callback，spine 动画事件
    /// </summary>
    protected virtual void DetectAndAttack()
    {
        Debug.Log("DetectAndAttack");
        Collider2D[] colliders =  Physics2D.OverlapBoxAll(center, radius, 0);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.tag.Equals("Player"))
            {
                Debug.Log("DetectAndAttack player");
                GameObject player = colliders[i].gameObject;
                //剪中了player后先关掉输入
                InputManager.GetInstance().InputDetectionActive = false;
                //取消能移动的ability
                player.GetComponent<HorizontalMove>().AbilityPermitted = false;
                player.GetComponent<Jump>().AbilityPermitted = false;
                player.GetComponent<PlayerController>().GravityActive(false);
                //重置速度避免有下落速度影响
                player.GetComponent<PlayerController>().SetForce(Vector2.zero);

                //生成叶子血

                GameObject blood = GameObject.Instantiate(Resources.Load("Prefab/leafBlood")) as GameObject;
                blood.transform.position = center;
                colliders[i].gameObject.GetComponent<ToBeFlower>().BeFlower(effect, transferPoint);
                AfterDetectAndAttack();
            }
        }
    }

    /// <summary>
    /// 剪中player后要做的事
    /// </summary>
    protected virtual void AfterDetectAndAttack()
    {
        
    }


    /// <summary>
    /// 一直画出出对应的检测方框
    /// </summary>
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, radius );
    }

}
