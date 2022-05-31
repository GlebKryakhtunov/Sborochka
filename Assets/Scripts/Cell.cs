using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
@brief Класс ячейки фигуры
*/
public class Cell : MonoBehaviour
{
    /**
@brief Координата x
*/
    public int x;
    /**
@brief Координата y
*/
    public int y;
    /**
@brief Пустая ячейка
*/
    public bool empty = true;
    /**
@brief Состояние ячейки
*/
    public bool state = false;

    public Vector2 size;
    private void Start()
    {
        GetComponent<BoxCollider2D>().size = size;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cell>().x == x && collision.gameObject.GetComponent<Cell>().y == y || empty)
        {
            state = true;
        }
        else state = false;
    }

}
