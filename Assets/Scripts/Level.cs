using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
@brief ����� ������
*/
public class Level
{
    private int sizeX = 0;
    private int sizeY = 0;
    [JsonProperty("name")]
    /**
@brief ��� ������
*/
    public string Name { set; get; }
    [JsonProperty("type")]
    /**
@brief ��� ������
*/
    public string Type { set; get; }
    [JsonProperty("state")]
    /**
@brief ��������� ������
*/
    public int State { set; get; }
    [JsonProperty("category")]
    /**
@brief ��������� ������
*/
    public string Category { set; get; }
    [JsonProperty("size_x")]
    /**
@brief ������ �� X
*/
    public int SizeX
    {
        set
        {
            if ((value - sizeX) > 0)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    for (int i = 0; i < (value - sizeX); i++)
                    {
                        Colors[j].Add(null);
                        Paths[j].Add(0);
                    }
                }
            }
            else if ((value - sizeX) < 0)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    for (int i = 0; i < (sizeX - value); i++)
                    {
                        Colors[j].RemoveAt(sizeX - i - 1);
                        Paths[j].RemoveAt(sizeX - i - 1);
                    }
                }

            }
            sizeX = value;
        }
        get { return sizeX; }
    }
    [JsonProperty("size_y")]
    /**
@brief ������ �� Y
*/
    public int SizeY
    {
        set
        {
            if ((value - sizeY) > 0)
            {
                for (int i = 0; i < (value - sizeY); i++)
                {
                    Colors.Add(new List<string>());
                    Paths.Add(new List<int>());
                    for (int j = 0; j < sizeX; j++)
                    {
                        Colors[sizeY + i].Add(null);
                        Paths[sizeY + i].Add(0);
                    }
                }

            }
            else if ((value - sizeY) < 0)
            {
                for (int i = 0; i < (sizeY - value); i++)
                {
                    Colors.RemoveAt(sizeY - i - 1);
                    Paths.RemoveAt(sizeY - i - 1);
                }

            }
            sizeY = value;
        }
        get { return sizeY; }
    }
    [JsonProperty("colors")]
    /**
@brief ������ ������ ������
*/
    public List<List<string>> Colors = new List<List<string>>();
    [JsonProperty("paths")]
    /**
@brief ������ ��������� ������� ������
*/
    public List<List<int>> Paths = new List<List<int>>();
    [JsonProperty("figures")]
    /**
@brief ������ �����
*/
    public List<Figure> Figures = new List<Figure>();
    /**
@brief ����������� ������
*/
    public Level(string Name, string Type, string Category, int SizeX, int SizeY)
    {
        this.Name = Name;
        this.Type = Type;
        this.Category = Category;
        this.SizeX = SizeX;
        this.SizeY = SizeY;
    }
}
