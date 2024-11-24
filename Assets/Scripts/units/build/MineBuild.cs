using UnityEngine;

using System.Xml;
using System;

public class MineBuild : Build
{

    public MineBuild(int FracId, XmlDocument CfgRoot) {
        FractionId = FracId;
        Hp = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[0].InnerText);
        Ar = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[1].InnerText);
        En = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[2].InnerText);
        Sp = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[3].InnerText);
        Vr = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[4].InnerText);
        At = Convert.ToInt32(CfgRoot.ChildNodes[FracId - 1].ChildNodes[5].InnerText);
        MaxHp = Hp;
        Type = Constants.BUILD_MINE;
        


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()//установит текстуру, в зависимости от фракции
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
