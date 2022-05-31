using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
@brief ����� ������ ������
*/
public class ButtonLevelsController : MonoBehaviour
{
    /**
@brief ��� ������
*/
    public Text Name;
    /**
@brief ��������� ������
*/
    public Image State;
    /**
@brief ��������������� �������
*/
    public Sprite UnLock;
    /**
@brief ���������������� �������
*/
    public Sprite Lock;
    /**
@brief �������� �������
*/
    public Sprite Time;
    /**
@brief ���������� �������
*/
    public Sprite Passed;
    /**
@brief ������
*/
    public Button btn;
    /**
@brief ����� ������
*/
    string mode = "Easy";
    /**
@brief ���������
*/
    string category;
    /**
@brief ����� �������
*/
    int number = 0;
    /**
@brief ������ ������
*/
    GameController _gameController;
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }
    /**
@brief ��������� ����� ������
*/
    public void SetName(int index)
    {
        Name.text = (index+1).ToString();
        number = index;
        btn.onClick.AddListener(() => { _gameController.ShowLevel(category, mode, number); });
    }
    /**
@brief ��������� ��������� ������
*/
    public void SetCategory(string text) => category = text;
    /**
@brief ��������� ������ ������
*/
    public void SetMode(string text) => mode = text;
    /**
@brief ��������� ��������� �������
*/
    public void SetState(int state) {
        if (state == 0) State.GetComponent<Image>().sprite = UnLock;
        if (state == -1) State.GetComponent<Image>().sprite = Lock;
        if (state == 1) State.GetComponent<Image>().sprite = Passed;
        if (state == 2) State.GetComponent<Image>().sprite = Time;
    }
}
