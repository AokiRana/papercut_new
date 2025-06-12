using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyDestruter : MonoBehaviour
{

    public Transform butterflyCreater;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("butterflyUp"))
        {
            Debug.Log("检测到蝴蝶");
            collision.transform.position = new Vector3(collision.gameObject.transform.position.x,butterflyCreater.position.y, 0);
            Debug.Log("修改了位置");
        }
    }
}
