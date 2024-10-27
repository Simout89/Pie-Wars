using UnityEngine;

public class Build : MonoBehaviour //базовый класс
{

    int FractionId;  //id фракции
    int Level; //уровень здания
    int Status; //состояние постройки(работает, не работает и улутшается)
    int Hp; //текущее кол-во прочности здания
    int MaxHp; //максимальное кол-во хп
     
    int[] BuffList = new int[5]; //список баффов(будет не списком интов)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
