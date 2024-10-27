using UnityEngine;
using System;


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

    void AddBuild(Vector3 position,  Hex HexMesh) //создает здание
    {

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        Debug.Log("touched at " + coordinates.ToString());
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //высота берятся из объекта сетки, в дальнейшем будут браться из файла сохранения карты

        Vector3 Center = HexMesh.cells[CellId].transform.position;

    }


}
