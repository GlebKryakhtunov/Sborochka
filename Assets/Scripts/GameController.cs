using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    int coins = 10000;
    /**
    @brief ���������� ���������
    */
    int hints = 10;
    /**
    @brief ��������� ����� (���/����)
    */
    bool stateSound = false;

    /**
    @brief ������ ��� ����
    */
    public GameObject backgroundPanel;
    /**
    @brief ���� ��� ������ ���������� ������ ������
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
     @brief ���� ��� ������ ���������
    */
    public GameObject categoriesGamesPanel;
    /**
    @brief ���� ��� ������ ������
    */
    public GameObject levelsGamesPanel;

    /**
    @brief ������ ������ ���������
    */
    public GameObject prefabCategroy;
    /**
    @brief ���� ���������
    */
    public GameObject categoriesPanel;
    /**
    @brief ���� ������
    */
    public GameObject levelGamesPanel;
    /**
    @brief ���� �����
    */
    public GameObject backgroundsGamesPanel;

    public GameObject imageGamesPanel;

    public GameObject hintsGamesPanel;

    public GameObject gridBackgrounds;
    public List<GameObject> btnCategories;

    public Dictionary<string, Dictionary<string, List<Level>>> Levels = new Dictionary<string, Dictionary<string, List<Level>>>();

    public GameObject prefabButtonLevel;
    public GameObject prefabButtonBackground;

    public GameObject levelsPanel;
    public List<GameObject> btnLevels;

    public Level currentLevel;
    public GameObject prefabCell;
    public GameObject gridLevel;

    public GameObject prefabFigure;
    public GameObject figuresButton;

    public GameObject prefabCellFig;
    public GameObject figs;

    public bool StartLevel = false;

    public string currentCategory;
    public string currentMode;
    public int currentNumberLevel;

    public GameObject panelGameOver;
    public bool PauseLevel = false;

    public List<bool> figPos = new List<bool>();
    public List<bool> figHints = new List<bool>();

    public string PauseCategory;
    public string PauseMode;
    public int PauseNumberLevel;

    public Button btnContinue;

    public GameObject panelPay;
    public Text PayMessage;

    /**
    @brief ���������
    */

    Dictionary<string, string> categories = new Dictionary<string, string>() {
        {"Cats", "������"},
        {"Plants", "��������"},
        {"Smiles", "������"},
    };
    int indexBackground = 0;
    int tempBackground = 0;
    public List<Sprite> imageBackground;
    public List<Sprite> imageBackgroundButton;
    public List<string> nameBackground;
    public List<int> coinsBackgrounds;
    public List<int> stateBackgrounds;

    public AudioSource sound;
    void Start()
    {
        coinsText.text = coins.ToString();
        hintsText.text = hints.ToString();
        sound.enabled = false;
        List<Level> lvls = new List<Level>();
        using (StreamReader fs = new StreamReader("Assets/Files/levels.json"))
        {
            string text = fs.ReadToEnd();
            lvls = JsonConvert.DeserializeObject<List<Level>>(text);
        }
        foreach (Level lvl in lvls) {
            if (!Levels.ContainsKey(lvl.Category)) {
                Levels.Add(lvl.Category, new Dictionary<string, List<Level>>());
            }

            if (!Levels[lvl.Category].ContainsKey(lvl.Type)) {
                Levels[lvl.Category].Add(lvl.Type, new List<Level>());
            }
            Levels[lvl.Category][lvl.Type].Add(lvl);
        }
        btnContinue.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartLevel) {
            if (figuresButton.transform.childCount == 0) {
                if (figs.transform.GetChild(figs.transform.childCount - 1).GetComponent<FigureController>().flag && !figs.transform.GetChild(figs.transform.childCount - 1).GetComponent<FigureController>().dragging)
                {
                    StartLevel = false;
                    currentLevel.State = 1;
                    if (currentMode == "Easy") {
                        coins += 10;
                    }
                    if (currentMode == "Medium")
                    {
                        coins += 20;
                    }
                    if (currentMode == "Hard") {
                        coins += 30;
                    }
                    panelGameOver.SetActive(true);
                    coinsText.text = coins.ToString();
                }
            }
        }
    }
    /**
    @brief ������� ��� �������� � ������� ����
    */
    public void ShowStartGame()
    {
        startGamePanel.SetActive(true);
        shopGamePanel.SetActive(false);
        categoriesGamesPanel.SetActive(false);
        levelsGamesPanel.SetActive(false);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(true);
        btnBack.SetActive(false);
        levelGamesPanel.SetActive(false);
        panelGameOver.SetActive(false);
    }
    /**
    @brief ������� ��� �������� � ���� ��������
    */
    public void ShowShop() {
        startGamePanel.SetActive(false);
        shopGamePanel.SetActive(true);
        categoriesGamesPanel.SetActive(false);
        levelsGamesPanel.SetActive(false);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(false);
        btnBack.SetActive(true);
        backgroundsGamesPanel.SetActive(false);
        imageGamesPanel.SetActive(false);
        hintsGamesPanel.SetActive(false);
    }
    /**
   @brief ������� ��� �������� � ���� �����
   */
    public void ShowBackgrounds() {
        shopGamePanel.SetActive(false);
        backgroundsGamesPanel.SetActive(true);
        panelPay.SetActive(false);
        foreach (Transform child in gridBackgrounds.transform) Destroy(child.gameObject);
        for (int i = 0; i < imageBackgroundButton.Count; i++) {
            GameObject obj = Instantiate(prefabButtonBackground, gridBackgrounds.transform);
            obj.GetComponent<ButtonBackgroundController>().SetIndex(i);
            obj.GetComponent<ButtonBackgroundController>().SetName(nameBackground[i]);
            obj.GetComponent<ButtonBackgroundController>().SetCoins(coinsBackgrounds[i]);
            obj.GetComponent<ButtonBackgroundController>().SetBackground(imageBackgroundButton[i]);
            obj.GetComponent<ButtonBackgroundController>().SetState(stateBackgrounds[i]);
        }
    }
    /**
    @brief ������� ��� ������ ����
    */
    public void SelectBackground(int index)
    {

        tempBackground = indexBackground;
        indexBackground = index;
        if (stateBackgrounds[index] == -1)
        {
            PayMessage.text = string.Format("������� ��� �� {0} ������?", coinsBackgrounds[index]);
            panelPay.SetActive(true);
        }
        else {
            backgroundPanel.GetComponent<Image>().sprite = imageBackground[index];
            for (int i = 0; i < stateBackgrounds.Count; i++) {
                if (stateBackgrounds[i] == 1) stateBackgrounds[i] = 0;
            }
            stateBackgrounds[index] = 1;
            ShowBackgrounds();
        }
    }
    /**
     @brief ������� ��� �������� � ���� ����������� ��������
     */
    public void ShowImage() {
        shopGamePanel.SetActive(false);
        imageGamesPanel.SetActive(true);
    }

    public void ShowHintsShop() {
        shopGamePanel.SetActive(false);
        hintsGamesPanel.SetActive(true);
    }
    /**
   @brief ������� ��� �������� � ���� ������ ������
   */
    public void ShowCategories()
    {
        startGamePanel.SetActive(false);
        shopGamePanel.SetActive(false);
        categoriesGamesPanel.SetActive(true);
        levelsGamesPanel.SetActive(false);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(false);
        btnBack.SetActive(true);
        foreach (Transform child in categoriesPanel.transform) Destroy(child.gameObject);
        btnCategories.Clear();
        foreach (var category in categories)
        {
            GameObject obj = Instantiate(prefabCategroy, categoriesPanel.transform);
            obj.GetComponent<ButtonCategoryController>().SetName(category.Value);
            obj.GetComponent<ButtonCategoryController>().SetCategory(category.Key);
            btnCategories.Add(obj);
        }
    }
    /**
    @brief ������� ��� �������� � ���� ������ ������
    */
    public void ShowLevels(string category, string mode) {
        currentCategory = category;
        currentMode = mode;
        startGamePanel.SetActive(false);
        shopGamePanel.SetActive(false);
        categoriesGamesPanel.SetActive(false);
        levelsGamesPanel.SetActive(true);
        levelGamesPanel.SetActive(false);
        btnSound.SetActive(false);
        btnBack.SetActive(true);
        panelGameOver.SetActive(false);
        panelPay.SetActive(false);
        Debug.Log(category);
        Debug.Log(mode);
        foreach (Transform child in levelsPanel.transform) Destroy(child.gameObject);
        btnLevels.Clear();
        int index = 0;
        try
        {
            foreach (var level in Levels[category][mode])
            {
                GameObject obj = Instantiate(prefabButtonLevel, levelsPanel.transform);
                obj.GetComponent<ButtonLevelsController>().SetName(index);
                obj.GetComponent<ButtonLevelsController>().SetCategory(level.Category);
                obj.GetComponent<ButtonLevelsController>().SetMode(level.Type);
                obj.GetComponent<ButtonLevelsController>().SetState(level.State);
                btnLevels.Add(obj);
                index += 1;
            }
        }
        catch (Exception e) {
            Debug.Log("������!!");
        } 
    }
    /**
    @brief ������� ��� �������� � ���� ������
    */
    public void ShowLevel(string category, string mode, int number)
    {
        currentLevel = Levels[category][mode][number];
        if (currentLevel.State != -1)
        {
            currentNumberLevel = number;
            startGamePanel.SetActive(false);
            shopGamePanel.SetActive(false);
            categoriesGamesPanel.SetActive(false);
            levelsGamesPanel.SetActive(false);
            levelGamesPanel.SetActive(true);
            btnSound.SetActive(false);
            btnBack.SetActive(true);
            if (!PauseLevel || PauseLevel && (PauseCategory != category || PauseMode != mode || PauseNumberLevel != number))
            {
                if (PauseLevel)
                {
                    if (Levels[PauseCategory][PauseMode][PauseNumberLevel].State == 2)
                    {
                        Levels[PauseCategory][PauseMode][PauseNumberLevel].State = 0;
                    }
                }
                figPos.Clear();
            }
            if (PauseLevel)
            {
                Levels[PauseCategory][PauseMode][PauseNumberLevel].State = 0;
            }
            foreach (Transform child in figuresButton.transform) Destroy(child.gameObject);
            foreach (Transform child in figs.transform) Destroy(child.gameObject);
            foreach (Transform child in gridLevel.transform) Destroy(child.gameObject);
            if (mode == "Hard")
            {
                gridLevel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(12, 12);
            }
            else {
                gridLevel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(28, 28);
            }
            gridLevel.GetComponent<GridLayoutGroup>().constraintCount = currentLevel.SizeX;

            for (int i = 0; i < currentLevel.SizeY; i++)
            {
                for (int j = 0; j < currentLevel.SizeX; j++)
                {
                    GameObject obj = Instantiate(prefabCell, gridLevel.transform);
                    obj.GetComponent<Cell>().x = j;
                    obj.GetComponent<Cell>().y = i;
                    if (currentLevel.Paths[i][j] == 1)
                    {
                        obj.GetComponent<Outline>().effectColor = new Color(0, 0, 0);
                    }
                }
            }
            int k = 0;
            figHints = new List<bool>();
            foreach (Figure fig in currentLevel.Figures)
            {
                GameObject figure = Instantiate(prefabFigure, figuresButton.transform);
                figure.GetComponent<GridLayoutGroup>().constraintCount = fig.MaxSizeX - fig.MinSizeX + 1;
                if (mode == "Hard")
                {
                    figure.GetComponent<GridLayoutGroup>().cellSize = new Vector2(12, 12);
                }
                else
                {
                    figure.GetComponent<GridLayoutGroup>().cellSize = new Vector2(28, 28);
                }
                figure.GetComponent<FigureController>().SetPos(gridLevel.transform.localPosition);
                figure.GetComponent<FigureController>().SetFigure(fig, this, k);
                figHints.Add(false);
                if (!PauseLevel)
                {
                    figPos.Add(false);
                    
                }
                else
                {
                    if (figPos[k])
                    {
                        figure.GetComponent<FigureController>().SetPosFigure();
                    }
                }
                k++;

            }
            btnContinue.enabled = false;
            PauseLevel = false;
            StartLevel = true;
        }
        else {
            if (mode == "Easy") {
                PayMessage.text = "������� ������� �� 30 ������?";
            }
            if (mode == "Medium")
            {
                PayMessage.text = "������� ������� �� 40 ������?";
            }
            if (mode == "Hard")
            {
                PayMessage.text = "������� ������� �� 50 ������?";
            }
            panelPay.SetActive(true);

        }
    }

    public void AcceptLevel() {
        ShowLevels(currentCategory, currentMode);
    }
    public void ShowPausedLevel() {
        ShowLevel(PauseCategory, PauseMode, PauseNumberLevel);
    }
    public void Back() {
        if (panelGameOver.activeSelf == true)
        {
            ShowLevels(currentCategory, currentMode);
        }
        else if (levelGamesPanel.activeSelf == true)
        {
            if (currentLevel.State == 0)
            {
                currentLevel.State = 2;
                StartLevel = false;
                PauseLevel = true;
                btnContinue.enabled = true;
                PauseCategory = currentCategory;
                PauseMode = currentMode;
                PauseNumberLevel = currentNumberLevel;
            }

            ShowLevels(currentCategory, currentMode);
        }
        else if (levelsGamesPanel.activeSelf == true)
        {
            ShowCategories();
        }
        else if (categoriesGamesPanel.activeSelf == true)
        {
            ShowStartGame();
        }
        else if (shopGamePanel.activeSelf == true)
        {
            ShowStartGame();
        }
        else if (backgroundsGamesPanel.activeSelf || imageGamesPanel.activeSelf || hintsGamesPanel.activeSelf)
        {
            ShowShop();
        }
    }
    public void AcceptPay() {
        if (levelsGamesPanel.activeSelf)
        {
            if (PayMessage.text == "������������ �������")
            {
                ShowLevels(currentCategory, currentMode);
            }
            else
            {
                if (currentMode == "Easy")
                {
                    if (coins >= 30)
                    {
                        coins -= 30;
                        currentLevel.State = 0;
                        coinsText.text = coins.ToString();
                        ShowLevels(currentCategory, currentMode);
                    }
                    else
                    {
                        PayMessage.text = "������������ �������";
                    }
                }
                if (currentMode == "Medium")
                {
                    if (coins >= 40)
                    {
                        coins -= 40;
                        currentLevel.State = 0;
                        coinsText.text = coins.ToString();
                        ShowLevels(currentCategory, currentMode); ;
                    }
                    else
                    {
                        PayMessage.text = "������������ �������";
                    }
                }
                if (currentMode == "Hard")
                {
                    if (coins >= 50)
                    {
                        coins -= 50;
                        currentLevel.State = 0;
                        coinsText.text = coins.ToString();
                        ShowLevels(currentCategory, currentMode);
                    }
                    else
                    {
                        PayMessage.text = "������������ �������";
                    }
                }
            }
        }
        else if(backgroundsGamesPanel.activeSelf){
            if (PayMessage.text == "������������ �������")
            {
                indexBackground = tempBackground;
                ShowBackgrounds();
            }
            else if (coins - coinsBackgrounds[indexBackground] >= 0)
            {
                stateBackgrounds[indexBackground] = 0;
                coins -= coinsBackgrounds[indexBackground];
                coinsText.text = coins.ToString();
                ShowBackgrounds();
            }
        }
        else if(hintsGamesPanel.activeSelf){
            panelPay.SetActive(false);
        }
    }
    public void CancelPay() {
        if (levelsGamesPanel.activeSelf)
        {
            ShowLevels(currentCategory, currentMode);
        }
        else if (backgroundsGamesPanel.activeSelf) {
            indexBackground = tempBackground;
            ShowBackgrounds();
        }
        else if (hintsGamesPanel.activeSelf)
        {
            panelPay.SetActive(false);
        }
    }

    public void PayHints(int index) {
        if (index == 0) {
            if (coins - 100 >= 0)
            {
                coins -= 100;
                hints += 5;
                coinsText.text = coins.ToString();
                hintsText.text = hints.ToString();
                
            }
            else {
                PayMessage.text = "������������ �������";
                panelPay.SetActive(true);
            }
        }
        else if (index == 1)
        {
            if (coins - 150 >= 0)
            {
                coins -= 150;
                hints += 10;
                coinsText.text = coins.ToString();
                hintsText.text = hints.ToString();

            }
            else
            {
                PayMessage.text = "������������ �������";
                panelPay.SetActive(true);
            }
        }
        else if (index == 2)
        {
            if (coins - 200 >= 0)
            {
                coins -= 200;
                hints += 20;
                coinsText.text = coins.ToString();
                hintsText.text = hints.ToString();

            }
            else
            {
                PayMessage.text = "������������ �������";
                panelPay.SetActive(true);
            }
        }
        else if (index == 3)
        {
            if (coins - 300 >= 0)
            {
                coins -= 300;
                hints += 40;
                coinsText.text = coins.ToString();
                hintsText.text = hints.ToString();

            }
            else
            {
                PayMessage.text = "������������ �������";
                panelPay.SetActive(true);
            }
        }
        else if (index == 4)
        {
            if (coins - 600 >= 0)
            {
                coins -= 600;
                hints += 100;
                coinsText.text = coins.ToString();
                hintsText.text = hints.ToString();

            }
            else
            {
                PayMessage.text = "������������ �������";
                panelPay.SetActive(true);
            }
        }
    }

    public void UseHint() {
        if (hints == 0) return;
        bool flag = false;
        foreach (bool test in figHints) if (!test) flag = true;
        if (!flag) return;
        hints -= 1;
        hintsText.text = hints.ToString();
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, figPos.Count);
        while(figPos[index] || figHints[index]) index = rnd.Next(0, figPos.Count);
        figHints[index] = true;
        foreach (Vector vec in currentLevel.Figures[index].coords) {
            Color fill;
            if (currentLevel.Colors[vec.y][vec.x] != null)
            {
                ColorUtility.TryParseHtmlString(currentLevel.Colors[vec.y][vec.x] + "77", out fill);
                gridLevel.transform.GetChild(vec.y * currentLevel.SizeX + vec.x).GetComponent<Image>().color = fill;
            }
        }
    }
    /**
    @brief ������� ��������� ��������� ����� (���/����)
    */
    public void ChangeSound() {
        if (!stateSound)
        {
            btnSound.GetComponent<Image>().sprite = soundOn;
            sound.enabled = true;
            stateSound = true;
        }
        else
        {
            btnSound.GetComponent<Image>().sprite = soundOff;
            sound.enabled = false;
            stateSound = false;
        }

    }
}
