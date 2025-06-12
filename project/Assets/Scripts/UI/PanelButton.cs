using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    public Image chooseImage;
    public PanelButton UpButton;
    public PanelButton DownButton;


    /// <summary>
    /// 选中要做的事
    /// </summary>
    public void Choose()
    {
        chooseImage.gameObject.SetActive(true);
    }

    /// <summary>
    /// 离开选中要做的事情
    /// </summary>
    public void ExitChoose()
    {
        chooseImage.gameObject.SetActive(false);
    }
}
