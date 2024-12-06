using UnityEngine;

using System.Xml;
using System;

public class MineBuild : BasedEntityClass
{
    


    public MineBuild(int FracId, XmlDocument CfgRoot) {
        FractionId = FracId;
        int Hp = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[0].InnerText);
        int Ar = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[1].InnerText);
        int En = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[2].InnerText);
        int Sp = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[3].InnerText);
        int Vr = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[4].InnerText);
        int At = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[5].InnerText);

        ObjType = Constants.BUILD_MINE;

        Char = new(Hp,Ar,En,Sp,Vr,At);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()//��������� ��������, � ����������� �� �������
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
