using UnityEngine;
using System;


public class Build : MonoBehaviour //������� �����
{

    

    int FractionId;  //id �������
    int Level; //������� ������
    int Status; //��������� ���������(��������, �� �������� � ����������)
    int Hp; //������� ���-�� ��������� ������
    int MaxHp; //������������ ���-�� ��
     
    int[] BuffList = new int[5]; //������ ������(����� �� ������� �����)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBuild(Vector3 position,  Hex HexMesh) //������� ������
    {

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        Debug.Log("touched at " + coordinates.ToString());
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //������ ������� �� ������� �����, � ���������� ����� ������� �� ����� ���������� �����

        Vector3 Center = HexMesh.cells[CellId].transform.position;

    }


}
