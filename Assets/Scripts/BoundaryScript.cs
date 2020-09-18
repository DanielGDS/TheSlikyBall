using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BoundaryScript : MonoBehaviour 
{
    // Переменная количества смертей
    int DeadValue;

    // Игровое айди
    string gameId = "3826137";

    // Запустить в тестовом решиме рекламу
    bool testMode = true;


    // Обьект спавнера
    public GameObject SpawnGenerator;
    // Экран ГеймОвера
    public GameObject GameOver;

    // Игрок
    public GameObject Player;

// Если игрок и игровые обьекты выходят за пределы коллайдера 
private void OnTriggerExit2D(Collider2D other)
    {
        // Найти игрока за пределами коллайдера.
        if (other.gameObject.tag == "Player")
        {
            // Если это игрок то, уничтожить его, запустить экран ГеймОвера, 
            // выключить время, и прибавить единицу к счетчику смертей.
            Destroy(other.gameObject);
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            DeadValue += 1;
        }
        // Если игрок умер больше 5 раз подряд, то включить ему рекламу и сбросить счетчик.
        if (DeadValue > 5)
        {
            Advertisement.Show();
            DeadValue = 0;
        }

        // Просто уничтожает любой обьект, который не является игроком.
        Destroy(other.gameObject);
    }

    private void Awake()
    {
        // Инициализирует рекламу
        Advertisement.Initialize(gameId, testMode);
    }
}
