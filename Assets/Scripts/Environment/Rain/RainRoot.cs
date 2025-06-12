using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainRoot : MonoBehaviour
{
    public GameObject umbrella;
    public GameObject umbrellaHandle;
    public GameObject FallRain;
    ///rain射线检测的层级
    public LayerMask DetectLayerMask;
    ///射线检测的条数
    public int RayNum = 30;
    public List<PaperBridgeHandle> _paperBrigdeList = new List<PaperBridgeHandle>();


    protected BoxCollider2D _collider;
    protected Vector2 leftTopPos;
    protected Vector2 rightTopPos;
    protected float _rayLength;
    protected RaycastHit2D[] hitinfos;
    protected string BloodRainPath = "Prefab/BloodRain/blood_rain";
    public bool isDetectPlayer;
    public bool isTimer;
    public bool isCreateBlood;
    ///射线检测player所在 hitinfos 中的下标
    protected int detectPlayerIndex;
    ///是否停止下雨检测了
    protected bool isStopRainDetect;
    protected IEnumerator createBloodCoroutine;




    private void Start()
    {
        Initilization();
    }

    protected void Initilization()
    {
        Physics2D.queriesStartInColliders = false;
        _collider = GetComponent<BoxCollider2D>();
        leftTopPos = _collider.bounds.center + new Vector3(-_collider.bounds.extents.x, _collider.bounds.extents.y);
        rightTopPos = _collider.bounds.center + new Vector3(_collider.bounds.extents.x, _collider.bounds.extents.y);
        _rayLength = _collider.bounds.size.y;
        hitinfos = new RaycastHit2D[RayNum];
        EventMgr.GetInstance().AddLinstener<Collider2D>("RainDeathCallback", RainDeathCallback);
    }

    private void FixedUpdate()
    {
        if (!isStopRainDetect)
        {
            Detect();
        }


    }

    /// <summary>
    /// 射线检测玩家
    /// </summary>
    protected void Detect()
    {
        if (hitinfos.Length != RayNum)
        {
            hitinfos = new RaycastHit2D[RayNum];
        }

        isDetectPlayer = false;
        detectPlayerIndex = 0;

        for (int i = 0; i < RayNum; i++)
        {
            Vector2 originPos = Vector2.Lerp(leftTopPos, rightTopPos, (float)i / (RayNum - 1));
            RaycastHit2D hitinfo = DebugHelper.RaycastAndDrawLine(originPos, Vector2.down, _rayLength, DetectLayerMask);
            hitinfos[i] = hitinfo;
            Collider2D collider = hitinfo.collider;
            if (collider != null && collider.gameObject.tag.Equals("Player"))
            {
                isDetectPlayer = true;
                detectPlayerIndex = i;
            }
        }

        //如果检测到player 且 还没有流血
        if (isDetectPlayer && !isTimer)
        {
            StartCoroutine(Timer(hitinfos[detectPlayerIndex].collider));
            createBloodCoroutine = CreateRainBlood(hitinfos[detectPlayerIndex].collider);
            StartCoroutine(createBloodCoroutine);
        }
    }






    /// <summary>
    /// 计时产生rainBlood的协程
    /// </summary>
    /// <param name="collider"></param>
    /// <returns></returns>
    protected IEnumerator CreateRainBlood(Collider2D collider)
    {
        isCreateBlood = true;

        if (collider == null || !isDetectPlayer || !isTimer)
        {
            isCreateBlood = false;
            yield break;
        }

      


        float t = 0;
        while (isDetectPlayer && isTimer)
        {
            if (t >= 0.2f)
            {
                string path = BloodRainPath + Random.Range(0, 4).ToString();
                GameObject rainBlood = GameObject.Instantiate(Resources.Load(path)) as GameObject;
                rainBlood.transform.position = collider.transform.position;
                t = 0;
            }

            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();

        }

        isCreateBlood = false;

    }

    /// <summary>
    /// 在雨中的计时
    /// </summary>
    /// <param name="collider"></param>
    /// <returns></returns>
    protected IEnumerator Timer(Collider2D collider)
    {
        isTimer = true;
        Debug.Log("计时开始");
        float t = 0;
        while (t <= 2.5f)
        {
            if (!isDetectPlayer)
            {
                isTimer = false;
                Debug.Log("主动计时结束");
              
                yield break;
            }
            t += Time.fixedDeltaTime;
            CreateRainBlood(collider);
            yield return new WaitForFixedUpdate();
        }

        StopCoroutine(createBloodCoroutine);
        Health health = collider.GetComponent<Health>();
        health.Damage(health.MaximumHealth, Health.DeathStyle.DeathwithoutFlower,()=>
        {
            EventMgr.GetInstance().EventTrigger<Collider2D>("RainDeathCallback", collider);
        });

        Debug.Log("计时结束");
        isTimer = false;
    }

    /// <summary>
    /// 在雨中死了后复活的回调
    /// </summary>
    /// <param name="collider"></param>
    public void RainDeathCallback(Collider2D collider)
    {
        PlayerController playerController = collider.GetComponent<PlayerController>();
        playerController.GravityActive(true);
        foreach (PaperBridgeHandle ph in _paperBrigdeList)
        {
            ph.ResetBrigde();
        }
        umbrella.GetComponent<PathMovement>().ResetPath();
        umbrellaHandle.GetComponent<UmbrellaHandle>().ResetHandleState();
        Debug.Log("重力应用");
    }

    /// <summary>
    /// 动画事件 当下雨结束的时候激活下落雨滴
    /// </summary>
    public void ActiveRainFall()
    {
        if (FallRain == null || FallRain.activeInHierarchy)
        {
            return;
        }
        MusicMgr.GetInstance().StopBkMusic();
        FallRain.SetActive(true);
        Debug.Log("ActiveRainFall desu");
    }

    /// <summary>
    /// 下雨停止检测玩家
    /// </summary>
    public void StopDetect()
    {
        isStopRainDetect = true;
        StopAllCoroutines();
    }
}
