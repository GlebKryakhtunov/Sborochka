using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonFigureController : EventTrigger
{
    private Figure figure;
    public Button btn;
    public bool dragging;
    public Transform trf;
    public GameObject prefabFigure;
    GameObject prgFigure;
    GameController _gameController;

    public void SetFigure(Figure fig, GameController gm) {
        _gameController = gm;
        figure = fig;
        List<GameObject> cells = new List<GameObject>();
        for (int i = 0; i < figure.SizeY; i++)
        {
            for (int j = 0; j < figure.SizeX; j++)
            {
                GameObject cell = Instantiate(_gameController.prefabCell, transform);
                cell.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                cells.Add(cell);
            }
        }
        foreach (Vector vector in figure.coords)
        {
            int index = (vector.y - figure.MinSizeY) * figure.SizeX + (vector.x - figure.MinSizeX);
            cells[index].GetComponent<Cell>().x = vector.x;
            cells[index].GetComponent<Cell>().y = vector.y;
            Color fill;
            ColorUtility.TryParseHtmlString(_gameController.currentLevel.Colors[vector.y][vector.x], out fill);
            cells[index].GetComponent<Image>().color = fill;
        }
    }

    private void Update()
    {
        if (dragging)
        {
            transform.localPosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            Debug.Log(transform.localPosition);
        }

    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        trf = transform;
        transform.SetParent(_gameController.levelGamesPanel.transform);
        dragging = true;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        transform.SetParent(_gameController.figuresButton.transform);
        dragging = false;
    }
}
