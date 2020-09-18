using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EmitterCoin : MonoBehaviour
{
    public GameObject coin;
    public float minDelay, maxDelay;

    private float nextLaunch;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Бесконечный спавп платфонрм
        if (Time.time > nextLaunch)
        {
            //Запуск
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            // Установка позиции
            var halfWidth = transform.localScale.x / 2;
            var positionX = Random.Range(-halfWidth, halfWidth);

            var newcoinPosition = new Vector3(
                positionX,
                transform.position.y,
                transform.position.z
            );
            Instantiate(coin, newcoinPosition, Quaternion.identity);
        }
    }
}
