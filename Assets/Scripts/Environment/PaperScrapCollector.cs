using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PaperScrapCollector : MonoBehaviour
{

    //��Ҫ�ռ�����ֽ����
    public short collectNum;
    //Ŀǰ��ֽ����
    public short currentPapaerNum = 0;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("MeI");
        collectNum = 3;
    }


    /// <summary>
    /// �ռ�����Ʒ��ı�������ɫ ������������ʵ��
    /// </summary>
    private void CollectAndChangeColor()
    {
        Debug.Log("change color");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PaperScrap"))
        {
            CollectAndChangeColor();
            currentPapaerNum++;
            if (currentPapaerNum >= collectNum)
            {
                Transfer();
                currentPapaerNum = 0;
            }
            //��������Ϸ����ǰ�Ȱ�tween�����ˣ���ֹ����Ϊ��
            DOTween.Kill(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// λ��Player��ָ���ص�
    /// </summary>
    private void Transfer()
    {
        _player.transform.position = this.transform.position;
        _player.GetComponent<Player>().ToVisiable();
        _player.GetComponent<PlayerController>().SetVerticalForce(20f);
        Debug.Log("//����");
        InputManager.GetInstance().InputDetectionActive = true;
        _player.GetComponent<HorizontalMove>().AbilityPermitted = true;
        _player.GetComponent<Jump>().AbilityPermitted = true;
        _player.GetComponent<PlayerController>().GravityActive(true);
    }
}
