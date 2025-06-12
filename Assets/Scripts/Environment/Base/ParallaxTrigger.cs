using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Ԫ���Ӳ����
/// </summary>
public class ParallaxTrigger : MonoBehaviour
{
    public List<GameObject> parallaxList;

    protected bool isActiveParallax = false;
    

    /// <summary>
    /// ��player��һ�ν��봥������ʱ�򣬼���Ҫ�Ӳ��ƶ����Ӳ�ű����Ӷ������Ӳ��ƶ�
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !isActiveParallax)
        {
            ParallaxElement parallax = null;
            foreach (GameObject obj in parallaxList)
            {
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    parallax = obj.transform.GetChild(i).GetComponent<ParallaxElement>();
                    if (parallax != null)
                    {
                        parallax.enabled = true;
                    }
                }

            }

            isActiveParallax = true;
        }
    }
}
