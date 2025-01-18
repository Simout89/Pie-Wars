using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;



//отвечает за управление юнитами: перемещение, активация способностей, построения 
//responsible for controlling units: moving, activating abilities, formations
public class UnitControl: MonoBehaviour
{

    private SelectUnits _selectedUnits;
    public void MoveUnits(Vector3 cords){
        //перемещает всех выбранных юнитов в точку(можно переместить 1 юнита)
        //moves all selected units to the point (can move 1 unit)
        foreach(Unit unit in _selectedUnits.SelectedUnist ){
            unit.Move(cords);
        }
    }

    public void AtackUnit(ref Unit trg){                   //атака 1 юнита
        foreach(Unit unit in _selectedUnits.SelectedUnist ){
            unit.AtackUnit(ref trg);
        }
    }

    public void Start(){
        _selectedUnits = this.GetComponent<SelectUnits>();
    }


}
