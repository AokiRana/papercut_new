using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrallyCameraTrigger : CameraTriggerBase
{
    public AudioSource rainBk;

    

    protected override void Awake()
    {
        _VCameraName = "grallyCamera";
        _inBlendTime = 1f;
        _exitBlednTime = 1f;
        base.Awake();
    }


    protected override void DoWhenTriggerEnter(Collider2D collision)
    {
        base.DoWhenTriggerEnter(collision);
        MusicVolumnMgr.GetInstance().VolumnValue = PlayerPrefs.GetInt("GlobalVolum");

        rainBk.volume = ((float)MusicVolumnMgr.GetInstance().VolumnValue/10) * 0.2f;
        rainBk.Play();

    }

    protected override void DoWhenTriggerExit(Collider2D collision)
    {
        base.DoWhenTriggerExit(collision);

        if (collision.gameObject.transform.position.x > cameraTriggerBox.bounds.center.x)
        {
            rainBk.volume = ((float)MusicVolumnMgr.GetInstance().VolumnValue / 10) * 1f;
            rainBk.Play();
        }

        if (collision.gameObject.transform.position.x < cameraTriggerBox.bounds.center.x)
        {
            rainBk.Pause();
        }

    }

}
