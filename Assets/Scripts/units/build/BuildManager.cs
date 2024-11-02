using System.Collections.Generic;
using System;
using UnityEngine;


//отвечает за создание новых зданий
//хранит массив всех зданий
//отвечает за уничтожение всех зданий
//отвечает за улучшения всех зданий
public class BuildManager : MonoBehaviour
{

    public MineBuild Mine;
    
 


    public List<Build> Builds = new List<Build>(); //массив всех зданий
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBuild(int Type, Vector3 position) //добовляет здание в массив и на карту
    {
        
        Hex HexMesh = GetComponent<Hex>();

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //id кдетки на которой будет здание
        Vector3 Center = HexMesh.cells[CellId].transform.position;//центр клетки на корой будет здание


    }


}
