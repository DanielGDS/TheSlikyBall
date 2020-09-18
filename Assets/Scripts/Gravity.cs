using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gravity : MonoBehaviour, IPointerDownHandler
{
    private Vector2 mousePos;
    // Ищет по тегу "Player" нужный префаб и изменяет ему гравитацию 
    private Rigidbody2D rb;
    // Получаем компонент для взаимодействия с физическим движком
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Перемещение обьекта в прострастве, вместе с платформой ()

    // Когда игрок прикасается к платформе с тегом "Платформ", 
    //срабатывает скрипт трансформации его координат с соотвествием координатам платформы.
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.transform.tag == "Platform")
            transform.parent = col.transform;
    }

    // Когда игрок выходит из коллайдера, 
    //то он отлипает от платформы и движется с соствествием своих координат.
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
            transform.parent = null;
    }


// По нажатию и касанию, срабатывает скрипт изменения гравитации.
private void Update()
    {
        // Получить позицию курсора согласно камере
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // При нажатии на левую клавишу мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Оттолкнуть обьект от позиции курсора
            rb.AddForce(-mousePos *2, ForceMode2D.Impulse);
 
        }
    }

 public void OnPointerDown(PointerEventData eventData)
    {
        // Меняет гравитацию на обратную и наоборот
        rb.gravityScale *= -1;

        // Оттолкнуть обьект от позиции курсора
        rb.AddForce(-mousePos * 2, ForceMode2D.Impulse);
    }
}
