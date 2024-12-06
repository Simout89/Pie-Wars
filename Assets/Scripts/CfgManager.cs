using System.Collections.Generic;
using System;
using UnityEngine;
using System.Xml;

using System.Configuration;
using System.Collections.Specialized;
using System.Reflection.Emit;
using UnityEngine.UIElements;

//����� ������� xml ����� ������� � ���������� ��������� � ����������
public class CfgManager : MonoBehaviour
{
    public string CfgBuildPath = "C:\\Users\\�����\\Desktop\\Pie-Wars\\Assets\\Scripts\\BuildCfg.xml";
    XmlDocument MainBuildCfg = new XmlDocument(); //������ ���������

    protected XmlNode PastryBuildCfg;////конфиг зданий теста
    protected XmlNode IceBuildCfg;//конфиг зданий мороженного
    protected XmlNode ChocolateBuildCfg;//конфиг зданий теста шоколада
    protected XmlNode SugarBuildCfg;//конфиг зданий сахара
    protected XmlElement cfgRoot;


    //���������� ��� ���������(���� ������ ��� ������)
    struct BasedEntityStruct  //����������� ��������� ��� 1 ������/�����
    {
        int HP;
        int AR;
        int EN;
        int SP;
        int VR;
        int AT;

        int AT_SPEED;   //�������� �����
        int VALUE;  //���-�� �������� ��� �����
        int SCORE; //������� ����� ����� ����
        int TIME; //����� ��������

        public void Create(int hp, int ar, int en, int sp, int vr, int at, int at_speed, int value, int score, int time)
        {
            this.HP = hp;
            this.AR = ar;
            this.EN = en;
            this.SP = sp;
            this.VR = vr;
            this.AT = at;
            this.AT_SPEED = at_speed;  //-1 ���� ������/���� �� ����� ���������
            this.VALUE = value;
            this.SCORE = score;
            this.TIME = time;
        }
    }

    public struct SUGAR_BUILD //��������� ��� ������ ������
    {
        BasedEntityStruct MainBuild;
        BasedEntityStruct Airfield;
        BasedEntityStruct Workshop;
        BasedEntityStruct Casern;
        BasedEntityStruct Mine;
        BasedEntityStruct Barracks;
        BasedEntityStruct Patrol;
        BasedEntityStruct Fort;

        public void Set(int BuildId,int hp, int ar, int en, int sp, int vr, int at, int at_speed, int value, int score, int time){

            switch(BuildId){

                case 0:
                    this.MainBuild.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 1:
                    this.Airfield.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 2:
                    this.Workshop.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 3:
                    this.Casern.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 4:
                    this.Mine.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 5:
                    this.Barracks.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 6:
                    this.Patrol.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
                case 7:
                    this.Fort.Create(hp, ar, en, sp, vr, at, at_speed, value, score, time);
                    break;
            }

        }
    }

    public SUGAR_BUILD SugarBldCfg = new SUGAR_BUILD();
    
    public CfgManager() {
        MainBuildCfg.Load(Constants.BUILD_CFG_PATH);
        cfgRoot = MainBuildCfg.DocumentElement; 

        PastryBuildCfg = cfgRoot.ChildNodes[0]; 
        IceBuildCfg = cfgRoot.ChildNodes[1]; 
        ChocolateBuildCfg = cfgRoot.ChildNodes[2]; 
        SugarBuildCfg = cfgRoot.ChildNodes[3]; 

    }


    void Start()
    {
        
    }

    public void ParsSugarBuildsCfg() {
        int FracId =4;//фракция сахар
        for(int i=0;i<8;i+=1){  //i-id здания
            int Hp = Convert.ToInt32(SugarBuildCfg.ChildNodes[i].ChildNodes[0].InnerText);
            int Ar = Convert.ToInt32(SugarBuildCfg.ChildNodes[i].ChildNodes[1].InnerText);
            int En = Convert.ToInt32(SugarBuildCfg.ChildNodes[i].ChildNodes[2].InnerText);
            int Sp = Convert.ToInt32(SugarBuildCfg.ChildNodes[i].ChildNodes[3].InnerText);
            int Vr = Convert.ToInt32(SugarBuildCfg.ChildNodes[i].ChildNodes[4].InnerText);
            int At = Convert.ToInt32(SugarBuildCfg.ChildNodes[i].ChildNodes[5].InnerText);
            int at_speed=0;
            int value=0;
            int score=0;
            int time=0;

            SugarBldCfg.Set(i,Hp,Ar,En,Sp,Vr,At, at_speed, value, score, time);//[1].Create(Hp,Ar,En,Sp,Vr,At);
        }
     }
    public void ParsSugarUnitsCfg() { }


}
