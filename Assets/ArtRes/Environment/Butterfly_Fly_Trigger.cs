using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly_Fly_Trigger : MonoBehaviour
{
    public GameObject Butterfly_Fly;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Butterfly_Fly.SetActive(true);
            Destroy(this.gameObject);
        }
    }

}
