using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    // Скрипт управляющий большей частью всей игры


    public bool shopGame;
    public bool menuGame;
    public bool pauseGame;
    public bool GameIsOver;

    // Количество полученных монет
    public static int MoneyCollect;

    // Игровой таймер выводимый на экран
    public static int Timer;

    // Текстовый элемент прошедшего в игре времени
    public UnityEngine.UI.Text scoreTextElement;

    // Текстовый элемент количества монет
    public UnityEngine.UI.Text CoinsTextElement;

    protected bool isStarted = false;

    // По стандарту количество монет равно нулю
    protected static int score = 0;

    // По стандарту игра не на паузе;
    public static bool GamePaused = false;


    // UI меню паузы
    public GameObject pauseMenuUI;

    // UI монет
    public GameObject scoreUI;

    // Ui ГеймОвера экрана
    public GameObject GameOverScreen;
    


    void Awake()
    {
        // Получить количество собранных монет
        MoneyCollect = PlayerPrefs.GetInt("MoneyCollect", MoneyCollect);
        CoinsTextElement.text = "0" + MoneyCollect;
    }
    public bool getIsStarted()
    {
        return isStarted;
    }
    void Start()
    {
        // По стандарту время идет
        Time.timeScale = 1f;

        // Таймер устанавлен на ноль
        scoreTextElement.text = "0";
    }

    public void increaseScore(int increment)
    {
        // Игрок получил монетку
        MoneyCollect += increment;

        // Сохраняет количество монет 
        PlayerPrefs.SetInt("MoneyCollect", MoneyCollect);
        PlayerPrefs.Save();

        // Выводит количество монет на экран
        CoinsTextElement.text = "0" + MoneyCollect;

    }

    void Update()
    {
        Timer = Time.frameCount / 50;
        scoreTextElement.text = "" + Timer + " s";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
 
            }

        }

    }

    // Если игра идет то -
    void ResumeGame()
    {
        // Меню паузы отключено
        pauseMenuUI.SetActive(false);

        // Время идет
        Time.timeScale = 1f;
        
        // Игра не на паузе
        GamePaused = false;

        // Вывод таймера на экран
        scoreUI.SetActive(true);
    }

    // Если игра на пауза то -
    void PauseGame()
    {
        // Меню паузы включено
        pauseMenuUI.SetActive(true);

        //Время заморожено
        Time.timeScale = 0f;

        // Игра на паузе
        GamePaused = true;

        // Таймер не выводится
        scoreUI.SetActive(false);
    }

    // Если игра окончена то -
    void GameOver()
    {
        // Без скриптовая часть игрыв
    }

}
