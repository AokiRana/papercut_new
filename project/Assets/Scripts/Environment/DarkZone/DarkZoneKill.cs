using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZoneKill : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            LevelManager.GetInstance().RespawnPlayer();
        }
    }
}
