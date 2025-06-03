using System;
using System.Collections;
using _Script.SelectedEntitys;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private CameraContoller _cameraContoller;
    [SerializeField] private UnitControl _unitControl;

    private void Update()
    {
        // ПКМ - команды/добыча/движение
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = default;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"ClickHandler: Попал в {hit.collider.gameObject.name}");
                
                // ПРИОРИТЕТ 1: Проверяем клик по ресурсу
                if(hit.collider.TryGetComponent(out ResourceNode resourceNode))
                {
                    HandleResourceClick(resourceNode);
                    return;
                }
                
                // ПРИОРИТЕТ 2: Обычное движение/атака
                _unitControl.ClickRMB(hit.point, hit.collider.gameObject);
            }
        }
        
        // ЛКМ - выделение юнитов
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = default;
            if(CheckNotEntity(hit , ray)) return;

            CheckOnUnit(hit, ray);
        }

        // ESC - отмена всех команд
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelAllCommandsForSelectedUnits();
        }

        // S - остановка (дополнительно)
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopSelectedUnits();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _cameraContoller.CameraMoveState = true;
        }
    }

    private void HandleResourceClick(ResourceNode resourceNode)
    {
        Debug.Log($"🎯 ClickHandler: Клик по ресурсу {resourceNode.ResourceType}");
        
        // Ctrl + ПКМ = отмена добычи
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Debug.Log("🛑 Ctrl + ПКМ: Отмена добычи");
            CancelAllCommandsForSelectedUnits();
            return;
        }
        
        if(resourceNode.IsEmpty)
        {
            Debug.Log("❌ Узел ресурса истощен!");
            return;
        }
        
        // Находим выделенных юнитов
        SelectedEntitysModel selectedModel = FindObjectOfType<SelectedEntitysModel>();
        if(selectedModel == null || selectedModel.SelectedEntitys.Count == 0)
        {
            Debug.Log("❌ Нет выделенных юнитов для добычи!");
            return;
        }

        Debug.Log($"✅ Отправляем {selectedModel.SelectedEntitys.Count} юнитов на добычу {resourceNode.ResourceType}");
        
        // Отправляем юнитов на добычу
        foreach(IEntity entity in selectedModel.SelectedEntitys)
        {
            HarvestCommand harvestCmd = new HarvestCommand(entity, resourceNode);
            
            if(Input.GetKey(KeyCode.LeftShift))
            {
                // Shift + ПКМ = добавить в очередь команд
                entity.AddCommand(harvestCmd);
                Debug.Log($"➕ Добыча добавлена в очередь: {entity.transform.name}");
            }
            else
            {
                // Просто ПКМ = заменить все команды на добычу
                entity.ClearCommandList();
                entity.AddCommand(harvestCmd);
                Debug.Log($"🎯 Новая команда добычи: {entity.transform.name}");
            }
        }
    }
    
    private void CancelAllCommandsForSelectedUnits()
    {
        SelectedEntitysModel selectedModel = FindObjectOfType<SelectedEntitysModel>();
        if(selectedModel == null || selectedModel.SelectedEntitys.Count == 0)
        {
            Debug.Log("❌ Нет выделенных юнитов для отмены команд!");
            return;
        }
        
        Debug.Log($"🛑 ОТМЕНА ВСЕХ КОМАНД для {selectedModel.SelectedEntitys.Count} юнитов");
        
        foreach(IEntity entity in selectedModel.SelectedEntitys)
        {
            entity.ClearCommandList();
            Debug.Log($"🛑 Команды отменены: {entity.transform.name}");
        }
        
        Debug.Log("✅ Все команды успешно отменены!");
    }

    private void StopSelectedUnits()
    {
        Debug.Log("🛑 ОСТАНОВКА выделенных юнитов (S)");
        CancelAllCommandsForSelectedUnits();
    }

    // Существующие методы остаются без изменений
    private bool CheckNotEntity(RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "Plane")
        {
            return true;
        }
        _cameraContoller.CameraMoveState = false;
        return false;
    }
    
    private void CheckOnUnit(RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.TryGetComponent(out UnitModel unitModel))
        {
            _unitControl.ClickOnUnit(unitModel);
        }
    }
}