using System.Collections.Generic;
using System;
using UnityEngine;
using System.Xml;

using System.Configuration;
using System.Collections.Specialized;

//�������� �� �������� ����� ������
//������ ������ ���� ������
//�������� �� ����������� ���� ������
//�������� �� ��������� ���� ������
public class BuildManager : MonoBehaviour
{

    string CfgBuildPath = "C:\\Users\\�����\\Desktop\\Pie-Wars\\Assets\\Scripts\\BuildCfg.xml";
    XmlDocument MainBuildCfg = new XmlDocument(); //������ ���������

    protected XmlNode PastryBuildCfg;//���� � �������� ������ ������� �����
    protected XmlNode IceBuildCfg;//���� � �������� ������ ������� ����������
    protected XmlNode ChocolateBuildCfg;//���� � �������� ������ ������� �������
    protected XmlNode SugarBuildCfg;//���� � �������� ������ ������� �����
    protected XmlElement cfgRoot;

    public List<Build> Builds = new List<Build>(); //������ ���� ������


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBuild(int Type, Vector3 position) //��������� ������ � ������ � �� �����
    {
        
        Hex HexMesh = GetComponent<Hex>();

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //id ������ �� ������� ����� ������
        Vector3 Center = HexMesh.cells[CellId].transform.position;//����� ������ �� ����� ����� ������


    }


}
