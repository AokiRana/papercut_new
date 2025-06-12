using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DarkZone : MonoBehaviour
{
    ///延迟展开的时间
    public float delayTime;
    ///darkzone展开的时间
    public float transferTime;
    ///darkZone展开到的sacleY
    public float targetScaleY;

    public List<GameObject> DisActive;
    public List<GameObject> ActiveList;

    float orignScanleY;
    protected Transform transform;
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        EventMgr.GetInstance().AddLinstener<string>("OpenDarkZone", OpenDarkZone);
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //设置为透明
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        orignScanleY = transform.localScale.y;

    }

    protected void OpenDarkZone(string info)
    {
        StartCoroutine(Expande());
    }

    protected IEnumerator Expande()
    {
        yield return new WaitForSeconds(delayTime);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        float t = 0;
        transform.localScale = new Vector3(transform.localScale.x, orignScanleY, transform.localScale.z);
        while (t < transferTime)
        {
            float newScaleY = Mathf.Lerp(orignScanleY,targetScaleY,(float) t/transferTime);
            transform.localScale = new Vector3(transform.localScale.x, newScaleY, transform.localScale.z);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        transform.localScale = new Vector3(transform.localScale.x, targetScaleY, transform.localScale.z);
        AfterExpane();
    }

    protected void AfterExpane()
    {
        foreach (GameObject obj in ActiveList)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in DisActive)
        {
            obj.SetActive(false);
        }
        //恢复玩家输入
        InputManager.GetInstance().InputDetectionActive = true;

        CinemachineFramingTransposer transposer = CameraMgr.GetInstance().PlayerVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        transposer.m_TrackedObjectOffset = new Vector3(0, 6, 0);
    }

}
