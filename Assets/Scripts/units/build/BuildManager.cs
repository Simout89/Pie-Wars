using System.Collections.Generic;
using System;
using UnityEngine;
using System.Xml;

using System.Configuration;
using System.Collections.Specialized;

//отвечает за создание новых зданий
//хранит массив всех зданий
//отвечает за уничтожение всех зданий
//отвечает за улучшения всех зданий
public class BuildManager : MonoBehaviour
{

    string CfgBuildPath = "C:\\Users\\Роман\\Desktop\\Pie-Wars\\Assets\\Scripts\\BuildCfg.xml";
    XmlDocument MainBuildCfg = new XmlDocument(); //конфик полностью

    protected XmlNode PastryBuildCfg;//узел с конфигом зданий фракции тесто
    protected XmlNode IceBuildCfg;//узел с конфигом зданий фракции мороженное
    protected XmlNode ChocolateBuildCfg;//узел с конфигом зданий фракции шоколад
    protected XmlNode SugarBuildCfg;//узел с конфигом зданий фракции сахар
    protected XmlElement cfgRoot;

    public List<Build> Builds = new List<Build>(); //массив всех зданий


    public BuildManager() {
        MainBuildCfg.Load(CfgBuildPath);
        cfgRoot = MainBuildCfg.DocumentElement; //корневой элемент

        PastryBuildCfg = cfgRoot.ChildNodes[0]; //настройки для зданий теста
        IceBuildCfg = cfgRoot.ChildNodes[1]; //настройки для зданий мороженного
        ChocolateBuildCfg = cfgRoot.ChildNodes[2]; //настройки для зданий шоколада
        SugarBuildCfg = cfgRoot.ChildNodes[3]; //настройки для зданий сахара

    }

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
