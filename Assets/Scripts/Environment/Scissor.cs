using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;



/// <summary>
/// Scissor �Ļ���
/// </summary>
public class Scissor : MonoBehaviour
{

    //׼��cut���ٶ�
    public float ReadyCutSpeed;
    public Transform effect;
    public Transform transferPoint; 

    ///���Ƽ�����animator���
    protected Animator _aniamator;
    ///������Կ���ֻ�ܵ����ֳ���Ӧanimator���е�spine event
    [SpineEvent]
    protected string eventName;

    ///�����û�� "����" MeI ��box����scene�е���box�ͻ��Ӧ�ĵ��� overlap �� gizmos
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
    /// ���� Cut ��Animator���� ,spine �����¼�
    /// </summary>
    protected virtual void CutOver()
    {
        _aniamator.SetBool("isCut", false);
        Debug.Log("iscut is false");
    }

    /// <summary>
    /// ���� twine ��Animator������spine �����¼�
    /// </summary>
    protected virtual void TwineOver()
    {
        _aniamator.SetBool("isTwine", false);
    }

    /// <summary>
    /// cut��ʼʱ ��Animator����,spine �����¼�
    /// </summary>
    protected virtual void StartCut()
    {
        
    }

    /// <summary>
    /// �ṩ�ⲿ���ã�ʹ��������
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
    /// �������е���һ˲�䴥����callback��spine �����¼�
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
                //������player���ȹص�����
                InputManager.GetInstance().InputDetectionActive = false;
                //ȡ�����ƶ���ability
                player.GetComponent<HorizontalMove>().AbilityPermitted = false;
                player.GetComponent<Jump>().AbilityPermitted = false;
                player.GetComponent<PlayerController>().GravityActive(false);
                //�����ٶȱ����������ٶ�Ӱ��
                player.GetComponent<PlayerController>().SetForce(Vector2.zero);

                //����Ҷ��Ѫ

                GameObject blood = GameObject.Instantiate(Resources.Load("Prefab/leafBlood")) as GameObject;
                blood.transform.position = center;
                colliders[i].gameObject.GetComponent<ToBeFlower>().BeFlower(effect, transferPoint);
                AfterDetectAndAttack();
            }
        }
    }

    /// <summary>
    /// ����player��Ҫ������
    /// </summary>
    protected virtual void AfterDetectAndAttack()
    {
        
    }


    /// <summary>
    /// һֱ��������Ӧ�ļ�ⷽ��
    /// </summary>
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, radius );
    }

}
