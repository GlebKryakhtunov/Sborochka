using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
@brief Класс вектора
*/
public class Vector
{
    [JsonProperty("x")]
    /**
@brief Координата x
*/
    public int x { get; set; }
    [JsonProperty("y")]
    /**
@brief Координата y
*/
    public int y { get; set; }
    /**
@brief Конструктор класса
*/
    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
