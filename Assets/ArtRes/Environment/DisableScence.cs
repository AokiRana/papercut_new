using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScence : MonoBehaviour
{
    public List<GameObject> Diaable;
    public List<GameObject> Active;
    public AudioClip areaClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            foreach (GameObject obj in Diaable)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in Active)
            {
                obj.SetActive(true);
            }

            BKMusicMgr.GetInstance().StopBK();
            if (areaClip != null)
            {
                BKMusicMgr.GetInstance().PlayBK(areaClip,true);
            }
            Destroy(this.gameObject);
        }

    }
}
