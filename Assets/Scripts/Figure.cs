using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
@brief ����� ������
*/
public class Figure
{
    [JsonProperty("size_x")]
    /**
@brief ������ �� X
*/
    public int SizeX { set; get; }
    [JsonProperty("size_y")]
    /**
@brief ������ �� Y
*/
    public int SizeY { set; get; }
    [JsonProperty("min_size_x")]
    /**
@brief ����������� ������ �� X
*/
    public int MinSizeX { set; get; }
    [JsonProperty("max_size_x")]
    /**
@brief ������������ ������ �� X
*/
    public int MaxSizeX { set; get; }
    [JsonProperty("min_size_y")]
    /**
@brief ����������� ������ �� Y
*/
    public int MinSizeY { set; get; }
    [JsonProperty("max_size_y")]
    /**
@brief ������������ ������ �� Y
*/
    public int MaxSizeY { set; get; }
    [JsonProperty("coors")]
    /**
@brief ������ ���������
*/
    public List<Vector> coords { set; get; }

}