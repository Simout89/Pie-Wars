using UnityEngine;
using System;


public class Build : MonoBehaviour //базовый класс
{



    protected int FractionId;  //id фракции
    protected int Level; //уровень здания
    protected int Status; //состояние постройки(работает, не работает и улутшается)
    protected int Hp; //текущее кол-во прочности здания
    protected int MaxHp; //максимальное кол-во хп
    protected int Type; //тип здания
     
    int[] BuffList = new int[5]; //список баффов(будет не списком интов)

    public Build(int FracId, int Type) //конструктор
    {
        FractionId = FracId;
        Level = 1;
        Status = Constants.BUILD_WORK_PASSIVE;


    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBuild(Vector3 position,  Hex HexMesh, int Orientation) //создает здание
    {

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        Debug.Log("touched at " + coordinates.ToString());
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //высота берятся из объекта сетки, в дальнейшем будут браться из файла сохранения карты

        Vector3 Center = HexMesh.cells[CellId].transform.position;



    }


}
