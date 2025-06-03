// Добавьте этот скрипт на любой GameObject для диагностики
using UnityEngine;
using System.Collections.Generic;
using _Script.SelectedEntitys;

public class MiningSystemDebug : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            CheckAllSystems();
        }
        
        if(Input.GetKeyDown(KeyCode.F2))
        {
            CreateSimpleResourceNode();
        }
        
        if(Input.GetKeyDown(KeyCode.F3))
        {
            TestDirectCommand();
        }
    }
    
    void CheckAllSystems()
    {
        Debug.Log("=== ДИАГНОСТИКА СИСТЕМЫ ===");
        
        // 1. Проверяем ResourceManager
        ResourceManager rm = FindObjectOfType<ResourceManager>();
        Debug.Log($"ResourceManager: {(rm != null ? "✅ НАЙДЕН" : "❌ НЕ НАЙДЕН")}");
        
        // 2. Проверяем EntitysController  
        EntitysController ec = FindObjectOfType<EntitysController>();
        Debug.Log($"EntitysController: {(ec != null ? "✅ НАЙДЕН" : "❌ НЕ НАЙДЕН")}");
        
        // 3. Проверяем MapClickHendler
        MapClickHendler mch = FindObjectOfType<MapClickHendler>();
        Debug.Log($"MapClickHendler: {(mch != null ? "✅ НАЙДЕН" : "❌ НЕ НАЙДЕН")}");
        
        // 4. Проверяем SelectedEntitysModel
        SelectedEntitysModel sem = FindObjectOfType<SelectedEntitysModel>();
        Debug.Log($"SelectedEntitysModel: {(sem != null ? "✅ НАЙДЕН" : "❌ НЕ НАЙДЕН")}");
        
        // 5. Проверяем юнитов
        Unit[] units = FindObjectsOfType<Unit>();
        Debug.Log($"Юнитов на сцене: {units.Length}");
        
        // 6. Проверяем узлы ресурсов
        ResourceNode[] nodes = FindObjectsOfType<ResourceNode>();
        Debug.Log($"Узлов ресурсов: {nodes.Length}");
        
        if(sem != null)
        {
            Debug.Log($"Выделенных юнитов: {sem.SelectedEntitys.Count}");
        }
        
        Debug.Log("=== НАЖМИТЕ F2 для создания узла ресурса ===");
    }
    
    void CreateSimpleResourceNode()
    {
        Debug.Log("🔨 Создаем простой узел ресурса...");
        
        // Создаем куб рядом с камерой
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 spawnPos = cameraPos + Camera.main.transform.forward * 10;
        spawnPos.y = 1;
        
        GameObject node = GameObject.CreatePrimitive(PrimitiveType.Cube);
        node.transform.position = spawnPos;
        node.transform.localScale = Vector3.one * 3;
        node.name = "DebugResourceNode";
        
        // Добавляем ResourceNode
        node.AddComponent<ResourceNode>();
        
        // Делаем красным чтобы выделялся
        node.GetComponent<Renderer>().material.color = Color.red;
        
        Debug.Log($"✅ Узел создан в позиции: {spawnPos}");
        Debug.Log("🎯 ИНСТРУКЦИЯ:");
        Debug.Log("1. Выделите юнита ЛКМ");
        Debug.Log("2. ПКМ по КРАСНОМУ кубу");
        Debug.Log("3. Смотрите консоль");
        Debug.Log("4. F3 - тест прямой команды");
    }
    
    void TestDirectCommand()
    {
        Debug.Log("🧪 Тестируем прямую команду добычи...");
        
        // Находим юнита и узел ресурса
        Unit unit = FindObjectOfType<Unit>();
        ResourceNode node = FindObjectOfType<ResourceNode>();
        
        if(unit == null)
        {
            Debug.LogError("❌ Юнит не найден!");
            return;
        }
        
        if(node == null)
        {
            Debug.LogError("❌ Узел ресурса не найден! Нажмите F2 сначала");
            return;
        }
        
        Debug.Log($"✅ Найден юнит: {unit.name}");
        Debug.Log($"✅ Найден узел: {node.name}");
        
        // Создаем команду напрямую
        HarvestCommand harvestCmd = new HarvestCommand(unit, node);
        
        // Добавляем команду юниту
        unit.ClearCommandList();
        unit.AddCommand(harvestCmd);
        
        Debug.Log("🎯 Команда добычи добавлена напрямую!");
        Debug.Log("Юнит должен пойти к узлу и начать добычу");
    }
}