using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
@brief ����� �������
*/
public class Vector
{
    [JsonProperty("x")]
    /**
@brief ���������� x
*/
    public int x { get; set; }
    [JsonProperty("y")]
    /**
@brief ���������� y
*/
    public int y { get; set; }
    /**
@brief ����������� ������
*/
    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
