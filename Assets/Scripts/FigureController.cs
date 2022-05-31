using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
@brief Класс, который контролирует перенос фигуры
*/
public class FigureController : EventTrigger
{
    /**
    @brief Данные фигуры
    */
    private Figure figure;
    /**
    @brief Состояние фигуры
    */
    public bool dragging;
    /**
    @brief Transform фигуры
   */
    public Transform trf;
    /**
   @brief Номер фигуры
  */
    public int numberFigure;
    /**
   @brief Объект игрока
  */
    GameController _gameController;
    /**
   @brief Массив ячеек 
  */
    List<GameObject> cells = new List<GameObject>();
    /**
    @brief Позиция фигуры 
   */
    Vector2 pos;

    public bool flag = false;
    /**
   @brief Функция, установки позиции
  */
    public void SetPos(Vector2 pos) {
        this.pos = pos;
    }
    /**
   @brief Функция, установки самой фигуры
  */
    public void SetFigure(Figure fig, GameController gm, int numberFigure)
    {
        _gameController = gm;
        figure = fig;
        this.numberFigure = numberFigure;
        for (int i = 0; i < figure.SizeY; i++)
        {
            for (int j = 0; j < figure.SizeX; j++)
            {
                GameObject cell = Instantiate(_gameController.prefabCellFig, transform);
                cell.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                cells.Add(cell);
            }
        }
        foreach (Vector vector in figure.coords)
        {
            int index = (vector.y - figure.MinSizeY) * figure.SizeX + (vector.x - figure.MinSizeX);
            cells[index].GetComponent<Cell>().x = vector.x;
            cells[index].GetComponent<Cell>().y = vector.y;
            cells[index].GetComponent<Cell>().empty = false;
            Color fill;
            ColorUtility.TryParseHtmlString(_gameController.currentLevel.Colors[vector.y][vector.x], out fill);
            cells[index].GetComponent<Image>().color = fill;
        }
    }
    /**
   @brief Функция, установки позиции фигуры
  */
    public void SetPosFigure() {
        transform.SetParent(_gameController.figs.transform);
        transform.localPosition = new Vector2(pos.x - 28 * _gameController.currentLevel.SizeX / 2 + 14 - _gameController.currentLevel.SizeX / 2 + figure.MinSizeX + figure.MinSizeX * 28 + (figure.MaxSizeX - figure.MinSizeX) / 2 + 28 * (figure.MaxSizeX - figure.MinSizeX) / 2,
                                                              pos.y + 28 * _gameController.currentLevel.SizeY / 2 - 14 + _gameController.currentLevel.SizeY / 2 - figure.MinSizeY - figure.MinSizeY * 28 - (figure.MaxSizeY - figure.MinSizeY) / 2 - 28 * (figure.MaxSizeY - figure.MinSizeY) / 2);
    }

    private void Update()
    {
        if (dragging)
        {
            transform.localPosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            bool state = true;
            foreach (GameObject cell in cells) {
                if (!cell.GetComponent<Cell>().state) state = false;
            }
            if (state) {
                
                flag = true;
            }
        }

    }
    /**
  @brief Функция, обработки нажатия на фигуру
 */
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!flag)
        {
            trf = transform;
            transform.SetParent(_gameController.figs.transform);
            dragging = true;
        }
    }
      /**
  @brief Функция, обработки отпускания фигуры
 */
    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        if (!flag)
        {
            transform.SetParent(_gameController.figuresButton.transform);  
        }
        else {
            transform.localPosition = new Vector2(pos.x - 28 * _gameController.currentLevel.SizeX / 2 + 14 - _gameController.currentLevel.SizeX / 2 + figure.MinSizeX + figure.MinSizeX * 28 + (figure.MaxSizeX - figure.MinSizeX) / 2 + 28 * (figure.MaxSizeX - figure.MinSizeX) / 2,
                                                          pos.y + 28 * _gameController.currentLevel.SizeY / 2 - 14 + _gameController.currentLevel.SizeY / 2 - figure.MinSizeY - figure.MinSizeY * 28 - (figure.MaxSizeY - figure.MinSizeY) / 2 - 28 * (figure.MaxSizeY - figure.MinSizeY) / 2);
            _gameController.figPos[numberFigure] = true;
        }

    }

}
