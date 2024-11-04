using UnityEngine;
using System;


public class Build : MonoBehaviour //базовый класс
{



    protected int FractionId;  //id фракции
    protected int Level; //уровень здания
    protected int Status; //состояние постройки(работает, не работает и улутшается)
    protected int Hp; //текущее кол-во прочности здания
    protected int Ar; //броня
    protected int En; //энергия
    protected int Sp; //скорость
    protected int Vr; //обзор
    protected int At; //атака



    protected int MaxHp; //максимальное кол-во хп
    protected int Type; //тип здания
     
    int[] BuffList = new int[5]; //список баффов(будет не списком интов)

    public Build() //конструктор
    {
        Level = 1;
        Status = Constants.BUILD_WORK_PASSIVE;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
