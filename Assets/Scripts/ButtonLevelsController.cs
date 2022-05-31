using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
@brief Класс кнопки уровня
*/
public class ButtonLevelsController : MonoBehaviour
{
    /**
@brief Имя уровня
*/
    public Text Name;
    /**
@brief Состояние уровня
*/
    public Image State;
    /**
@brief Заблокированный уровень
*/
    public Sprite UnLock;
    /**
@brief Разблокированный уровень
*/
    public Sprite Lock;
    /**
@brief Активный уровень
*/
    public Sprite Time;
    /**
@brief Пройденный уровень
*/
    public Sprite Passed;
    /**
@brief Кнопка
*/
    public Button btn;
    /**
@brief Режим уровня
*/
    string mode = "Easy";
    /**
@brief Категория
*/
    string category;
    /**
@brief Номер уровеня
*/
    int number = 0;
    /**
@brief Объект игрока
*/
    GameController _gameController;
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }
    /**
@brief Установка имени уровня
*/
    public void SetName(int index)
    {
        Name.text = (index+1).ToString();
        number = index;
        btn.onClick.AddListener(() => { _gameController.ShowLevel(category, mode, number); });
    }
    /**
@brief Установка категории уровня
*/
    public void SetCategory(string text) => category = text;
    /**
@brief Установка режима уровня
*/
    public void SetMode(string text) => mode = text;
    /**
@brief Установка состояния уровень
*/
    public void SetState(int state) {
        if (state == 0) State.GetComponent<Image>().sprite = UnLock;
        if (state == -1) State.GetComponent<Image>().sprite = Lock;
        if (state == 1) State.GetComponent<Image>().sprite = Passed;
        if (state == 2) State.GetComponent<Image>().sprite = Time;
    }
}
