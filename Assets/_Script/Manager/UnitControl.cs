using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitControl : MonoBehaviour
{
    private List<UnitModel> _selectedUnits = new(); 

    public void ClickOnUnit(UnitModel unitModel)
    {
        if (unitModel.TeamId == 0) // 0 - id игрока
        {
            foreach (var unit in _selectedUnits)
            {
                if (unit == unitModel)
                {
                    _selectedUnits.Remove(unit);
                    Debug.Log("Убран юнит: " + unit.name);
                    return;
                }
            }
            _selectedUnits.Add(unitModel);
            Debug.Log("Добавлен юнит: " + unitModel.name);
        }
        else
        {
            Debug.Log("Вражеский юнит");
        }
    }
    
    public void ClickRMB(Vector3 coordinates, GameObject gameObject)
    {
        Debug.Log($"UnitControl: ПКМ команда движения к {coordinates}");
        
        foreach (var unit in _selectedUnits)
        {
            // Отменяем текущие команды добычи
            Unit unitComponent = unit.GetComponent<Unit>();
            if(unitComponent != null)
            {
                unitComponent.ClearCommandList();
                Debug.Log($"🛑 Команды отменены для {unit.name}, идет к {coordinates}");
            }
            
            unit.GoTo(coordinates);
        }
        Debug.Log($"ПКМ: {_selectedUnits.Count} юнитов получили команду движения");
    }
}