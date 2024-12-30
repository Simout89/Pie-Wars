using System.IO;
using System;
using System.Diagnostics.CodeAnalysis;

using UnityEngine;
using System.Collections.Generic;

public class Config : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private string CfgPath="";
    private List<int> CfgData = new List<int>();
    public Config(string Path){
        CfgPath = Path;
        this.Read();
    }
    public Config(){
        CfgPath = Constants.CFG_PATH;
        this.Read();
    }

    private int Read(){     //читаем данные из файла
        try{
            string line;
            int id;
            int data;
            StreamReader sr = new StreamReader(CfgPath);
            line = sr.ReadLine();

            while (line != null){
            id = Convert.ToInt32(line.Split('/')[0]);
            data = Convert.ToInt32(line.Split(':')[1]);
            line = sr.ReadLine();
            CfgData.Add(data);
            }
            sr.Close();
            return 1;
       
        }
        catch(Exception e){
            Console.WriteLine("Cfg Error: " + e.Message);
            return 0;
        }
    }
}
