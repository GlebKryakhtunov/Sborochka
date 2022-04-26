using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
@mainpage
���� "��������" ������������ ����� ������� �����. � �������� ���� ��� ��������� ������� ��������� ��������, �� ������� �� �������� �������
*/
/**
@brief �����, ������� ������������ �������� ������
@detailed ������������ ��� �������� ������
*/
public class GameController : MonoBehaviour
{
    /**
    @brief ������ ������
    */
    int coins = 150;
    /**
    @brief ���������� ���������
    */
    int hints = 150;
    /**
    @brief ��������� ����� (���/����)
    */
    bool stateSound = false;
    /**
    @brief ���� ��� ������ ������ ������
    */
    public Text coinsText;
    /**
    @brief ���� ��� ������ ���������� ���������
    */
    public Text hintsText;

    /**
    @brief ������ ������������ ����� 
    */
    public Sprite soundOn;
    /**
    @brief ������ ����������� �����
    */
    public Sprite soundOff;

    /**
    @brief ������ ����������/��������� �����
    */
    public GameObject btnSound;
    /**
    @brief ������ �����
    */
    public GameObject btnBack;

    /**
    @brief ��������� ����
    */
    public GameObject startGamePanel;
    /**
    @brief ���� ��������
    */
    public GameObject shopGamePanel;
    /**
    @brief ���� ��� ������ ������
    */
    public GameObject levelsGamesPanel;
    /**
    @brief ���� ������
    */
    public GameObject levelGamesPanel;

    /**
    @brief ������������ ������
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
    @brief ������� ��� �������� � ������� ����
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
    @brief ������� ��� �������� � ���� ��������
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
    @brief ������� ��� �������� � ���� ������
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
    @brief ������� ��� �������� � ���� ������ ������
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
    @brief ������� ��������� ��������� ����� (���/����)
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
