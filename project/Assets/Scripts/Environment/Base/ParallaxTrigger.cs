using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 元素视差触发器
/// </summary>
public class ParallaxTrigger : MonoBehaviour
{
    public List<GameObject> parallaxList;

    protected bool isActiveParallax = false;
    

    /// <summary>
    /// 当player第一次进入触发器的时候，激活要视差移动的视差脚本，从而保持视差移动
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
