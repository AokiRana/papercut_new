using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinalPlayabeTrigger : MonoBehaviour
{
    public List<GameObject> ActiveList;
    public PlayableDirector finalPlayable;
    public float delayTime;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(PlayFinal(collision));
        }
    }


    protected IEnumerator PlayFinal(Collider2D collision)
    {

        InputManager.GetInstance().InputDetectionActive = false;
        yield return new WaitForSeconds(delayTime);
        foreach (GameObject obj in ActiveList)
        {
            obj.SetActive(true);
        }
        finalPlayable.Play();


    }
}
