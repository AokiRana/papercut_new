using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InputManager.GetInstance().InputDetectionActive = false;
            SceneMgr.GetInstance().LoadScene("UIScene");
        }
    }
}
