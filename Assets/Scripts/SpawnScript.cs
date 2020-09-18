using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // ПустойГеймОбьект с скриптом
    public GameObject SpawnGenerator;

    // Префаб обьект - Игрок
    [SerializeField] private GameObject Player;

    // Координаты спавна
    [SerializeField] private Transform spawn;
    private Vector3 SpawnPOS;


    void Awake()
    {
        // Установить точку спавна на следующих координатах
        SpawnPOS = new Vector3(-5, -2, -0);
    }
    void Update()
    {
        // Включить течение времени
        Time.timeScale = 1f;

        // Создать игрока на точке спавна
        Instantiate(Player, SpawnPOS, Quaternion.identity);

        // Выключить СпавнГенератор 
        SpawnGenerator.SetActive(false);
    }
}
