using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyOnTimeScript : MonoBehaviour
{
    public float secondsToDestroy = 20f;
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
}


