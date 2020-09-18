using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    // Публичная переменная скорости для быстрой смены в редакторе
    public float speed;
    
    // Закрытая переменная скорости перемещения
    float speedTransform;
    float TimeScale;

    //Подвергаймый физике обьект
    Rigidbody2D Scroll;

    void Start()
    {
      // Получить при старте скрипта компонент Rigidbody
      Scroll =  GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Получить игровое время деленное на тысячу
        TimeScale = (Time.time / 1000) + 1;
        speedTransform = speed * TimeScale;


        // Переместить платформу вправо-влево
        Scroll.transform.Translate(speedTransform, 0, 0);

    }
}
