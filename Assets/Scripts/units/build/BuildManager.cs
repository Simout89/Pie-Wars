using System.Collections.Generic;
using System;
using UnityEngine;
using System.Xml;

using System.Configuration;
using System.Collections.Specialized;
using System.Reflection.Emit;
using UnityEngine.UIElements;

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

    public List<BasedUnitClass> BuildList = new List<BasedUnitClass>(); //массив всех зданий

   
    public MineBuild MinePrefab;





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
        Vector3 position = new Vector3(17f,0f,14f);
        AddBuild(Constants.BUILD_MINE, position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBuild(int TypeBuild, Vector3 position) //добовляет здание в массив и на карту
    {

        //position = transform.InverseTransformPoint(position);
        //HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        //Debug.Log("touched at " + coordinates.ToString());
        //int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;  

        Hex HexMesh = GetComponent<Hex>();

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //id кдетки на которой будет здание
        Vector3 t = new Vector3(0f, 0.5f, 0f);
        Vector3 Center = HexMesh.cells[CellId].transform.position*2f - t;//центр клетки на корой будет здание
        Debug.Log(Center);
        Debug.Log(CellId);

        switch (TypeBuild)
        {
            case Constants.BUILD_MINE:
                //HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
                //cell.transform.localPosition = position;
                BasedUnitClass bld = Instantiate<MineBuild>(MinePrefab);
                bld.transform.localPosition = Center;
                BuildList.Add(bld);
                break;



        }


    }


}
