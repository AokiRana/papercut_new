using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainBubbleEffect : MonoBehaviour
{
    public Animator aniamtor;

    private void Awake()
    {
        aniamtor = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        aniamtor.enabled = true;
    }


    public void DesActive()
    {
        aniamtor.enabled = false;
        this.gameObject.SetActive(false);
        Debug.Log("Ê§»î");
    }
}
