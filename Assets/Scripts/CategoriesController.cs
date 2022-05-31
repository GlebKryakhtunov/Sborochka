using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
@brief ����� ������ "���������"
*/
public class CategoriesController : MonoBehaviour
{
    /**
@brief ������ ���������
*/
    public Sprite easyCategory;
    /**
@brief ������� ���������
*/
    public Sprite mediumCategory;
    /**
@brief ������� ���������
*/
    public Sprite hardCategory;
    /**
@brief ������ ������
*/
    GameController _gameController;
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }
    /**
@brief  �������� ������ ������ ���������
*/
    public void ShowEasy() {
        foreach (GameObject obj in _gameController.btnCategories) {
            obj.GetComponent<ButtonCategoryController>().SetSprite(easyCategory);
            obj.GetComponent<ButtonCategoryController>().SetMode("Easy");
        }
    }
    /**
@brief �������� ������ ������� ���������
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
@brief �������� ������ ������� ���������
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
