using UnityEngine;
using System;


public class Build : MonoBehaviour //������� �����
{



    protected int FractionId;  //id �������
    protected int Level; //������� ������
    protected int Status; //��������� ���������(��������, �� �������� � ����������)
    protected int Hp; //������� ���-�� ��������� ������
    protected int Ar; //�����
    protected int En; //�������
    protected int Sp; //��������
    protected int Vr; //�����
    protected int At; //�����



    protected int MaxHp; //������������ ���-�� ��
    protected int Type; //��� ������
     
    int[] BuffList = new int[5]; //������ ������(����� �� ������� �����)

    public Build() //�����������
    {
        Level = 1;
        Status = Constants.BUILD_WORK_PASSIVE;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
