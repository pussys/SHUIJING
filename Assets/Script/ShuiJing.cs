using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 水晶的颜色
/// </summary>
public enum Color
{
    Red = 1,//红
    Blue,//蓝
    Green//绿
}


public class ShuiJing {

    public Color color;
    public int num;
    public ShuiJing(Color _c, int _n)
    {
        color = _c;
        num = _n;
    }

}
