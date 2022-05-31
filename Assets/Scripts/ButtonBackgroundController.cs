using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
@brief Класс, контрлирующий фон игры
*/
public class ButtonBackgroundController : MonoBehaviour
{
    /**
@brief Индекс фона
*/
    int index;
    /**
@brief Кнопка с фоном
*/
    public Button btn;
    /**
@brief Имя фона
*/
    public Text Name;
    /**
@brief Текст стоимости фона
*/
    public Text coinsText;
    /**
@brief Стоимость фона
*/
    int coins = 20;
    /**
@brief Значок коинов
*/
    public GameObject Coins;
    /**
@brief Состояние фона
*/
    public Image State;
    /**
@brief Значок купленного фона
*/
    public Sprite UnLock;
    /**
@brief Значок заблокированного фона
*/
    public Sprite Lock;
    /**
@brief Значок выбранного фона
*/
    public Sprite Passed;
    /**
@brief Объект игрока
*/
    GameController _gameController;
  // Start is called before the first frame update
  void Start()
  {
      coinsText.text = coins.ToString();
      _gameController = GameObject.FindObjectOfType<GameController>();
      btn.onClick.AddListener(() => { _gameController.SelectBackground(index); });
  }
    /**
@brief Установка индекса фона
*/
    public void SetIndex(int ind) {
      index = ind;
  }
    /**
@brief Установка имени фона
*/
    public void SetName(string name){
      Name.text = name;
  }
    /**
@brief Установка фона
*/
    public void SetBackground(Sprite sprite) {
      btn.GetComponent<Image>().sprite = sprite;
  }
    /**
@brief Установка стоимости фона
*/
    public void SetCoins(int coins) {
      this.coins = coins;
      coinsText.text = coins.ToString();
  }
    /**
@brief Установка состояния фона
*/
    public void SetState(int state)
  {
      if (state == 0) State.GetComponent<Image>().sprite = UnLock;
      else if (state == -1) State.GetComponent<Image>().sprite = Lock;
      else if (state == 1) State.GetComponent<Image>().sprite = Passed;

      if (state == -1)
      {
          Coins.SetActive(true);
      }
      else {
          Coins.SetActive(false);
      }
  }
}
