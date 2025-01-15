using System.IO;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using System.Collections.Generic;

//не умеет менять cfg, только читать//can't change cfg, only read




public class Config: MonoBehaviour{       //ТУТ ХРАНЯТСЯ ВСЕ НАСТРОЙКИ ДЛЯ ВСЕХ СУЩНОСТЕЙ//ALL SETTINGS FOR ALL ENTITIES ARE STORED HERE
    private string CfgPath = "D:\\cfg_v2.dat";
    //private string CfgPath = Constants.CFG_PATH;
    private BinaryWriter writer;
    private BinaryReader reader;

    public List<EntityCfg> CfgData = new List<EntityCfg>();

    //public Config(string Path){
        //CfgPath = Path;
    //}

    void Start(){
        Read();
    }
    
    public void Read(){ //считает весь файл и запишет в массив//reads the entire file and writes it to an array
        reader = new BinaryReader(File.Open(CfgPath, FileMode.OpenOrCreate));
        double[] data = new double[12]; //сюда запишем данные из файла для 1 сущности//here we will write data from the file for 1 entity
        int i=0;
        while (reader.PeekChar() > -1){
            
            data[i]=reader.ReadDouble();
            Console.WriteLine(i);
            if(i==11){
                CfgData.Add(new EntityCfg(data));
                i=0;
                continue;
            }
            i+=1;
        }
        reader.Close();
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