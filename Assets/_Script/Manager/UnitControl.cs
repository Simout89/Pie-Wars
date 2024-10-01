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
                    Debug.Log("Убран юнит: ");
                    return;
                }
            }
            _selectedUnits.Add(unitModel);
            Debug.Log("Добавлен юнит: ");
        }
        else
        {
            Debug.Log("Вражеский юнит");
        }
    }
    
    public void ClickRMB(Vector3 coordinates, GameObject gameObject)
    {
        foreach (var unit in _selectedUnits)
        {
            unit.GoTo(coordinates);
        }
        Debug.Log("Нажато rmb: ");
    }
}
