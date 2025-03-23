using System.IO;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using System.Collections.Generic;

//не умеет менять cfg, только читать//can't change cfg, only read


public class EntityCfg{    //настройки для отдельной сющбности // settings for a separate entity
    public double HP;
    public double AR;
    public double EN;
    public double SP;
    public double VR;
    public double AT;
    public double ATS;
    public double AT_RANGE;
    public double COST_JR;
    public double COST_CK;
    public double SCORE;
    public double TIME_SPAWN;
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