using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainRoot : MonoBehaviour
{
    public GameObject umbrella;
    public GameObject umbrellaHandle;
    public GameObject FallRain;
    ///rain���߼��Ĳ㼶
    public LayerMask DetectLayerMask;
    ///���߼�������
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
    ///���߼��player���� hitinfos �е��±�
    protected int detectPlayerIndex;
    ///�Ƿ�ֹͣ��������
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
    /// ���߼�����
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

        //�����⵽player �� ��û����Ѫ
        if (isDetectPlayer && !isTimer)
        {
            StartCoroutine(Timer(hitinfos[detectPlayerIndex].collider));
            createBloodCoroutine = CreateRainBlood(hitinfos[detectPlayerIndex].collider);
            StartCoroutine(createBloodCoroutine);
        }
    }






    /// <summary>
    /// ��ʱ����rainBlood��Э��
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
    /// �����еļ�ʱ
    /// </summary>
    /// <param name="collider"></param>
    /// <returns></returns>
    protected IEnumerator Timer(Collider2D collider)
    {
        isTimer = true;
        Debug.Log("��ʱ��ʼ");
        float t = 0;
        while (t <= 2.5f)
        {
            if (!isDetectPlayer)
            {
                isTimer = false;
                Debug.Log("������ʱ����");
              
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

        Debug.Log("��ʱ����");
        isTimer = false;
    }

    /// <summary>
    /// ���������˺󸴻�Ļص�
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
        Debug.Log("����Ӧ��");
    }

    /// <summary>
    /// �����¼� �����������ʱ�򼤻��������
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
    /// ����ֹͣ������
    /// </summary>
    public void StopDetect()
    {
        isStopRainDetect = true;
        StopAllCoroutines();
    }
}
