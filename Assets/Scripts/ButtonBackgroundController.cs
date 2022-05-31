using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
@brief �����, ������������� ��� ����
*/
public class ButtonBackgroundController : MonoBehaviour
{
    /**
@brief ������ ����
*/
    int index;
    /**
@brief ������ � �����
*/
    public Button btn;
    /**
@brief ��� ����
*/
    public Text Name;
    /**
@brief ����� ��������� ����
*/
    public Text coinsText;
    /**
@brief ��������� ����
*/
    int coins = 20;
    /**
@brief ������ ������
*/
    public GameObject Coins;
    /**
@brief ��������� ����
*/
    public Image State;
    /**
@brief ������ ���������� ����
*/
    public Sprite UnLock;
    /**
@brief ������ ���������������� ����
*/
    public Sprite Lock;
    /**
@brief ������ ���������� ����
*/
    public Sprite Passed;
    /**
@brief ������ ������
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
@brief ��������� ������� ����
*/
    public void SetIndex(int ind) {
      index = ind;
  }
    /**
@brief ��������� ����� ����
*/
    public void SetName(string name){
      Name.text = name;
  }
    /**
@brief ��������� ����
*/
    public void SetBackground(Sprite sprite) {
      btn.GetComponent<Image>().sprite = sprite;
  }
    /**
@brief ��������� ��������� ����
*/
    public void SetCoins(int coins) {
      this.coins = coins;
      coinsText.text = coins.ToString();
  }
    /**
@brief ��������� ��������� ����
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
