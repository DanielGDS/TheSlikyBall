using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    // Обькт игровой пол-потолок
    public GameObject floor;

    // Минимальная и максимальная задержка
    public float minDelay, maxDelay;

    // Следущий запуск
    private float nextLaunch;

    void FixedUpdate()
    {
        //Бесконечный спавп платформ
        if (Time.time > nextLaunch)
        {
            //Запуск
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            // Установка позиции
            var newfloorPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z
            );
            // Создать платформу, на полученной позиции
            Instantiate(floor, newfloorPosition, Quaternion.identity);
        }
    }
}
