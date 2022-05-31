using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
@brief Класс фигуры
*/
public class Figure
{
    [JsonProperty("size_x")]
    /**
@brief Размер по X
*/
    public int SizeX { set; get; }
    [JsonProperty("size_y")]
    /**
@brief Размер по Y
*/
    public int SizeY { set; get; }
    [JsonProperty("min_size_x")]
    /**
@brief Минимальный размер по X
*/
    public int MinSizeX { set; get; }
    [JsonProperty("max_size_x")]
    /**
@brief Максимальный размер по X
*/
    public int MaxSizeX { set; get; }
    [JsonProperty("min_size_y")]
    /**
@brief Минимальный размер по Y
*/
    public int MinSizeY { set; get; }
    [JsonProperty("max_size_y")]
    /**
@brief Максимальный размер по Y
*/
    public int MaxSizeY { set; get; }
    [JsonProperty("coors")]
    /**
@brief Массив координат
*/
    public List<Vector> coords { set; get; }

}