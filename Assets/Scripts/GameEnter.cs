using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour
{
    public AudioClip startBKMusic;


    void Awake()
    {
        InitilizationGame();
    }


    public void InitilizationGame()
    {

        InputManager.GetInstance().InputDetectionActive = true ;
        BKMusicMgr.GetInstance().PlayBK(startBKMusic,true);

    }



}
