using System.IO;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using System.Collections.Generic;

//не умеет менять cfg, только читать//can't change cfg, only read


public class EntityCfg{    //настройки для отдельной сющбности // settings for a separate entity
    private double HP;
    private double AR;
    private double EN;
    private double SP;
    private double VR;
    private double AT;
    private double ATS;
    private double AT_RANGE;
    private double COST_JR;
    private double COST_CK;
    private double SCORE;
    private double TIME_SPAWN;
    public EntityCfg(double[] data){
        HP = data[0];
        AR = data[1];
        EN = data[2];
        SP = data[3];
        VR = data[4];
        AT = data[5];
        ATS = data[6];
        AT_RANGE = data[7];
        COST_JR = data[8];
        COST_CK = data[9];
        SCORE = data[10];
        TIME_SPAWN = data[11];
    }

    public double[] getAll(){    
            return new double[] { this.HP, this.AR, this.EN, this.SP, this.VR, this.AT, this.ATS, this.AT_RANGE, this.COST_JR, this.COST_CK,this.SCORE, this.TIME_SPAWN };
    }
     public void Damage(double dmg)
        {           
            dmg = dmg * 0.1 * this.AR;
            this.HP -= dmg;
        }
        public void DamageSugar(double dmg)              
        {
            if (dmg <= this.AR)
            {
                this.AR -= dmg;
            }
            else
            {
                dmg -= this.AR;
                this.AR = 0;
                this.HP -= dmg;
            }
        }

        public void EnRegen()
        {           
            this.EN += Constants.EN_REGEN;
        }

        public void Change_EN(int en)
        {            
            this.EN -= en;
        }
}




public class Config: MonoBehaviour{       //ТУТ ХРАНЯТСЯ ВСЕ НАСТРОЙКИ ДЛЯ ВСЕХ СУЩНОСТЕЙ//ALL SETTINGS FOR ALL ENTITIES ARE STORED HERE
    private string CfgPath = "D:\\cfg_v2.dat";
    //private string CfgPath = Constants.CFG_PATH;
    private BinaryWriter _writer;
    private BinaryReader _reader;

    public List<EntityCfg> CfgData = new List<EntityCfg>();

    //public Config(string Path){
        //CfgPath = Path;
    //}

    void Awake(){
        Read();
    }
    
    public void Read(){ //считает весь файл и запишет в массив//reads the entire file and writes it to an array
        _reader = new BinaryReader(File.Open(CfgPath, FileMode.OpenOrCreate));
        double[] data = new double[12]; //сюда запишем данные из файла для 1 сущности//here we will write data from the file for 1 entity
        int i=0;
        int count=0;
        
        while (count<Constants.COUNT_ENTITY){//(reader.PeekChar() > -1){//9- колличество юнитов/зданий в конфиге
            
            data[i]=_reader.ReadDouble();
            
            if(i==11){
                CfgData.Add(new EntityCfg(data));
                i=0;
                count+=1;
                continue;
            }
            i+=1;
        }
        _reader.Close();
        
        
    }
    //public void Writre(double[] data, int ind){ //занишет данные в файл ind - номер записи
        //writer = new BinaryWriter(File.Open(CfgPath, FileMode.OpenOrCreate));
        //writer.Seek(96*ind, SeekOrigin.Begin);
        //for (int i=0;i<12;i++){
            //writer.Write(data[i]);
        //}
        //writer.Close(); 
    //}


}