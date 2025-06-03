using System.IO;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

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


public class Config: MonoBehaviour
{
    private string CfgPath => Path.Combine(Application.streamingAssetsPath, "cfg_v2.dat");
    private BinaryReader _reader;
    public List<EntityCfg> CfgData = new List<EntityCfg>();

    void Awake(){
        Read();
    }
    
    public void Read(){
        try 
        {
            // Проверяем существование файла
            if(!File.Exists(CfgPath))
            {
                Debug.LogWarning($"Файл конфигурации не найден: {CfgPath}. Создаем данные по умолчанию.");
                CreateDefaultConfig();
                return;
            }

            _reader = new BinaryReader(File.Open(CfgPath, FileMode.Open));
            double[] data = new double[12];
            int i = 0;
            int count = 0;
            
            while (count < Constants.COUNT_ENTITY && _reader.BaseStream.Position < _reader.BaseStream.Length)
            {
                try
                {
                    data[i] = _reader.ReadDouble();
                }
                catch(EndOfStreamException)
                {
                    Debug.LogWarning("Достигнут конец файла конфигурации раньше времени");
                    break;
                }
                
                if(i == 11)
                {
                    CfgData.Add(new EntityCfg(data));
                    i = 0;
                    count += 1;
                    continue;
                }
                i += 1;
            }
            _reader.Close();
            
            Debug.Log($"Загружено {CfgData.Count} конфигураций сущностей");
        }
        catch(Exception ex)
        {
            Debug.LogError($"Ошибка при чтении конфига: {ex.Message}");
            CreateDefaultConfig();
        }
    }

    private void CreateDefaultConfig()
    {
        Debug.Log("Создаем конфигурации по умолчанию");
        
        // Создаем несколько типов сущностей с разными характеристиками
        for(int i = 0; i < Constants.COUNT_ENTITY; i++)
        {
            double[] defaultData = {
                100 + i * 10, // HP
                10 + i * 2,   // AR  
                50 + i * 5,   // EN
                3 + i * 0.5,  // SP - скорость
                20 + i * 3,   // VR
                15 + i * 2,   // AT
                1,            // ATS
                10 + i,       // AT_RANGE
                10 + i,       // COST_JR
                15 + i * 2,   // COST_CK
                100 + i * 10, // SCORE
                5 + i * 0.5   // TIME_SPAWN
            };
            
            CfgData.Add(new EntityCfg(defaultData));
        }
        
        Debug.Log($"Создано {CfgData.Count} конфигураций по умолчанию");
    }
}