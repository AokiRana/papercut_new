using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneMgr.GetInstance().LoadScene("UIScene");
    }

   
}
