using System.Collections.Generic;
using System;
using UnityEngine;
using System.Xml;

using System.Configuration;
using System.Collections.Specialized;
using System.Reflection.Emit;
using UnityEngine.UIElements;

//�������� �� �������� ����� ������
//������ ������ ���� ������
//�������� �� ����������� ���� ������
//�������� �� ��������� ���� ������
public class BuildManager : MonoBehaviour
{

    string CfgBuildPath = "C:\\Users\\RomaA\\OneDrive\\Рабочий стол\\Pie-Wars\\Assets\\Scripts\\BuildCfg.xml";
    XmlDocument MainBuildCfg = new XmlDocument(); //������ ���������

    protected XmlNode PastryBuildCfg;//���� � �������� ������ ������� �����
    protected XmlNode IceBuildCfg;//���� � �������� ������ ������� ����������
    protected XmlNode ChocolateBuildCfg;//���� � �������� ������ ������� �������
    protected XmlNode SugarBuildCfg;//���� � �������� ������ ������� �����
    protected XmlElement cfgRoot;

    public List<BasedUnitClass> BuildList = new List<BasedUnitClass>(); //������ ���� ������

   
    public MineBuild MinePrefab;





    public BuildManager() {
        MainBuildCfg.Load(CfgBuildPath);
        cfgRoot = MainBuildCfg.DocumentElement; //�������� �������

        PastryBuildCfg = cfgRoot.ChildNodes[0]; //��������� ��� ������ �����
        IceBuildCfg = cfgRoot.ChildNodes[1]; //��������� ��� ������ �����������
        ChocolateBuildCfg = cfgRoot.ChildNodes[2]; //��������� ��� ������ ��������
        SugarBuildCfg = cfgRoot.ChildNodes[3]; //��������� ��� ������ ������

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

    public void AddBuild(int TypeBuild, Vector3 position) //��������� ������ � ������ � �� �����
    {

        //position = transform.InverseTransformPoint(position);
        //HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        //Debug.Log("touched at " + coordinates.ToString());
        //int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;  

        Hex HexMesh = GetComponent<Hex>();

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //id ������ �� ������� ����� ������
        Vector3 t = new Vector3(0f, 0.5f, 0f);
        Vector3 Center = HexMesh.cells[CellId].transform.position*2f - t;//����� ������ �� ����� ����� ������
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
