using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    // Физичный обьект - монетка
    Rigidbody2D Coin;

    // Защищенная вызываемая переменная
    protected GameControllerScript gameControllerScript;


    void Start()
    {
        // Монетка это обьект Rigidbody
        Coin = GetComponent<Rigidbody2D>();

        // Найти на сцене обьект с тегом "ГеймКонтроллер" и получить его копмонент
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

    }

    // При вхождении в коллайдер
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Если это игрок
        if (col.tag == "Player")
        {
            // Вызвать ГеймКонтроллерСкрипт и его переменную, вместе с единицой int.
            gameControllerScript.increaseScore(1);

            // Уничтожить монетку со сцены
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // Каждый кадр поворачивать монетку по кругу
        transform.Rotate(0, 1.0f, 0);
    }
}
