using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 土地的状态
/// </summary>
public enum Status
{
    common,
    developmenting,//开垦
    plant,//增种
    maigc,//魔法瓶
    harvest//收获
}
public enum Devestatus
{
    underdevelopment,//未开垦
    development,//已开垦
    yeszhongzhi
}

public class Ground
{
    public Status status;
    public int num;
    public Devestatus deve;
    public Ground(Status 状态, int 水晶数,Devestatus 开垦状态)
    {
        status = 状态;
        num = 水晶数;
        deve = 开垦状态;
    }
    //private static Ground gr;
    //private Ground()
    //{ }
    //public static Ground GetIntance()
    //{
    //    if (gr != null)
    //    {
    //        gr = new Ground();
    //    }
    //    return gr;
    //}
}
