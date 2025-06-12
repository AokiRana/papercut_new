using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Image mask;
    public float showTime;

    public AudioClip UIMusic;

    private void Start()
    {
        Debug.Log("生成startpanel");
        UIMgr.GetInstance().ShowPanel<BKPanel>();
        UIMgr.GetInstance().ShowPanel<StartPanel>();
        UIMgr.GetInstance().ShowPanel<mask>();
        mask = UIMgr.GetInstance().panelDic["mask"].transform.GetChild(0).GetComponent<Image>();
        MusicVolumnMgr.GetInstance().SetVolumn(5);
        PlayerPrefs.SetInt("GlobalVolum", MusicVolumnMgr.GetInstance().VolumnValue);
        BKMusicMgr.GetInstance().StopBK();
        BKMusicMgr.GetInstance().PlayBK(UIMusic,true);

        StartCoroutine(Show());



    }


    /// <summary>
    /// 使mask渐变消失
    /// </summary>
    /// <returns></returns>
    protected IEnumerator Show()
    {

        float t = 0;

        while (t <= showTime)
        {

            float newAplha = Mathf.Lerp(1, 0, t / showTime);
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, newAplha);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 0);
    }

}
