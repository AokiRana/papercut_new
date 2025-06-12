using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StudioScene : MonoBehaviour
{

    public Image mask;

    public float showTime;
    public float stayTime;
    public float exitTime;


   
    void Start()
    {
        UnityEngine.Cursor.visible = false;
        StartCoroutine(Show());
    }

    protected IEnumerator Show()
    {

        yield return new WaitForSeconds(1.5f);

        float t = 0;

        while (t <= showTime)
        {

            float newAplha = Mathf.Lerp(1, 0, t / showTime);
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, newAplha);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 0);


        yield return new WaitForSeconds(stayTime);

        t = 0;
        while (t <= exitTime)
        {

            float newAplha = Mathf.Lerp(0, 1, t / exitTime);
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, newAplha);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 1);

        SceneMgr.GetInstance().LoadScene("UIScene");

    }

}
