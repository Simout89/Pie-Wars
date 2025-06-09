using UnityEngine;

public class trasheynik : Unit
{
    void Start(){
        // Проверяем, что Config существует
        GameObject configObj = GameObject.Find("EnityConfig");
        if(configObj != null)
        {
            Config config = configObj.GetComponent<Config>();
            if(config != null && config.CfgData != null && config.CfgData.Count > 2)
            {
                Characteristics = config.CfgData[2];
                Debug.Log($"Characteristics загружены для {gameObject.name}: SP = {Characteristics.SP}");
            }
            else
            {
                Debug.LogError("Config или CfgData не найдены!");
                InitializeDefaultCharacteristics();
            }
        }
        else
        {
            Debug.LogError("GameObject 'EnityConfig' не найден на сцене!");
            InitializeDefaultCharacteristics();
        }
    }

    // Создаем характеристики по умолчанию если конфиг не загрузился
    private void InitializeDefaultCharacteristics()
    {
        double[] defaultData = {
            100, // HP
            10,  // AR
            50,  // EN
            20,   // SP - скорость
            20,  // VR
            15,  // AT
            1,   // ATS
            10,  // AT_RANGE
            10,  // COST_JR
            15,  // COST_CK
            100, // SCORE
            5    // TIME_SPAWN
        };
        
        Characteristics = new EntityCfg(defaultData);
        Debug.Log($"Использованы характеристики по умолчанию для {gameObject.name}");
    }
}