using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
@brief Класс кнопки "Категория"
*/
public class CategoriesController : MonoBehaviour
{
    /**
@brief Легкая категория
*/
    public Sprite easyCategory;
    /**
@brief Средняя категория
*/
    public Sprite mediumCategory;
    /**
@brief Сложная категория
*/
    public Sprite hardCategory;
    /**
@brief Объект игрока
*/
    GameController _gameController;
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }
    /**
@brief  Показать уровни легкой категории
*/
    public void ShowEasy() {
        foreach (GameObject obj in _gameController.btnCategories) {
            obj.GetComponent<ButtonCategoryController>().SetSprite(easyCategory);
            obj.GetComponent<ButtonCategoryController>().SetMode("Easy");
        }
    }
    /**
@brief Показать уровни средней категории
*/
    public void ShowMedium()
    {
        foreach (GameObject obj in _gameController.btnCategories)
        {
            obj.GetComponent<ButtonCategoryController>().SetSprite(mediumCategory);
            obj.GetComponent<ButtonCategoryController>().SetMode("Medium");
        }
    }
    /**
@brief Показать уровни сложной категории
*/
    public void ShowHard()
    {
        foreach (GameObject obj in _gameController.btnCategories)
        {
            obj.GetComponent<ButtonCategoryController>().SetSprite(hardCategory);
            obj.GetComponent<ButtonCategoryController>().SetMode("Hard");
        }
    }
}
