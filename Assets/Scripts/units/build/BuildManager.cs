using System.Collections.Generic;
using System;
using UnityEngine;


//�������� �� �������� ����� ������
//������ ������ ���� ������
//�������� �� ����������� ���� ������
//�������� �� ��������� ���� ������
public class BuildManager : MonoBehaviour
{

    public MineBuild Mine;
    
 


    public List<Build> Builds = new List<Build>(); //������ ���� ������
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
