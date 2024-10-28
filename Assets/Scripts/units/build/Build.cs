using UnityEngine;
using System;


public class Build : MonoBehaviour //������� �����
{



    protected int FractionId;  //id �������
    protected int Level; //������� ������
    protected int Status; //��������� ���������(��������, �� �������� � ����������)
    protected int Hp; //������� ���-�� ��������� ������
    protected int MaxHp; //������������ ���-�� ��
    protected int Type; //��� ������
     
    int[] BuffList = new int[5]; //������ ������(����� �� ������� �����)

    public Build(int FracId, int Type) //�����������
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

    void AddBuild(Vector3 position,  Hex HexMesh, int Orientation) //������� ������
    {

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        Debug.Log("touched at " + coordinates.ToString());
        int CellId = coordinates.X + coordinates.Z * HexMesh.width + coordinates.Z / 2; //������ ������� �� ������� �����, � ���������� ����� ������� �� ����� ���������� �����

        Vector3 Center = HexMesh.cells[CellId].transform.position;



    }


}
