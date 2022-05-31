using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCategoryController : MonoBehaviour
{
    public Text Name;
    public Button btn;
    string mode = "Easy";
    string category;

    GameController _gameController;
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }
    public void SetName(string text) {
        Name.text = text;
    }
    public void SetCategory(string text) {
        category = text;
        btn.onClick.AddListener( () => { _gameController.ShowLevels(category, mode); });
    }
    public void SetMode(string text) => mode = text;

    public void SetSprite(Sprite sp) {
        btn.GetComponent<Image>().sprite = sp;
    }
}
