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
    /// ѡ��Ҫ������
    /// </summary>
    public void Choose()
    {
        chooseImage.gameObject.SetActive(true);
    }

    /// <summary>
    /// �뿪ѡ��Ҫ��������
    /// </summary>
    public void ExitChoose()
    {
        chooseImage.gameObject.SetActive(false);
    }
}
