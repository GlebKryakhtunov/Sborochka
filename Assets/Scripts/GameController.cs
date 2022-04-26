using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
@mainpage
Игра "Сборочка" представляет собой блочный паззл. В процессе игры Вам предстоит собрать несколько картинок, за которые Вы получите награду
*/
/**
@brief Класс, который контролирует действия игрока
@detailed Обрабатывает все действия игрока
*/
public class GameController : MonoBehaviour
{
    /**
    @brief Баланс игрока
    */
    int coins = 150;
    /**
    @brief Количество подсказок
    */
    int hints = 150;
    /**
    @brief Состояние звука (вкл/выкл)
    */
    bool stateSound = false;
    /**
    @brief Поле для вывода коинов игрока
    */
    public Text coinsText;
    /**
    @brief Поле для вывода количества подсказок
    */
    public Text hintsText;

    /**
    @brief Значок выключенного звука 
    */
    public Sprite soundOn;
    /**
    @brief Значок включенного звука
    */
    public Sprite soundOff;

    /**
    @brief Кнопка отключения/включения звука
    */
    public GameObject btnSound;
    /**
    @brief Кнопка назад
    */
    public GameObject btnBack;

    /**
    @brief Стартовое окно
    */
    public GameObject startGamePanel;
    /**
    @brief Окно магазина
    */
    public GameObject shopGamePanel;
    /**
    @brief Окно для выбора уровня
    */
    public GameObject levelsGamesPanel;
    /**
    @brief Окно уровня
    */
    public GameObject levelGamesPanel;

    /**
    @brief Инциализация данных
    */
    void Start()
    {
        coinsText.text = coins.ToString();
        hintsText.text = hints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /**
    @brief Функция для перехода в главное окно
    */
    public void ShowStartGame()
    {
        startGamePanel.SetActive(true);
        shopGamePanel.SetActive(false);
        levelsGamesPanel.SetActive(false);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(true);
        btnBack.SetActive(false);
    }
    /**
    @brief Функция для перехода в окно магазина
    */
    public void ShowShop() {
        startGamePanel.SetActive(false);
        shopGamePanel.SetActive(true);
        levelsGamesPanel.SetActive(false);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(false);
        btnBack.SetActive(true);
    }
    /**
    @brief Функция для перехода в окно уровня
    */
    public void ShowLevel()
    {
        startGamePanel.SetActive(false);
        shopGamePanel.SetActive(false);
        levelsGamesPanel.SetActive(false);
        levelGamesPanel.SetActive(true); 
        btnSound.SetActive(false);
        btnBack.SetActive(true);

    }
    /**
    @brief Функция для перехода в окно выбора уровня
    */
    public void ShowLevels() {
        startGamePanel.SetActive(false);
        shopGamePanel.SetActive(false);
        levelsGamesPanel.SetActive(true);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(false);
        btnBack.SetActive(true);
    }
    /**
    @brief Функция изменения состояния звука (вкл/выкл)
    */
    public void ChangeSound() {
        if (!stateSound)
        {
            btnSound.GetComponent<Image>().sprite = soundOn;
            stateSound = true;
        }
        else
        {
            btnSound.GetComponent<Image>().sprite = soundOff;
            stateSound = false;
        }

    }
}
