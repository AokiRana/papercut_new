using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{

    public Button btn;
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            Debug.Log("µã»÷");
            StartPanel panel = GameObject.Find("StartPanel").GetComponent<StartPanel>();
            panel.TxtStartEvent();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
