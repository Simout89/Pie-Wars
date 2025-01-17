using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;



//отвечает за управление юнитами: перемещение, активация способностей, построения 
//responsible for controlling units: moving, activating abilities, formations
public class UnitControl: MonoBehaviour
{

    public void MoveUnits(Vector3 cords){
        //перемещает всех выбранных юнитов в точку(можно переместить 1 юнита)
        //moves all selected units to the point (can move 1 unit)
        foreach(Unit unit in this.GetComponent<SelectUnits>().SelectedUnist ){
            unit.Move(cords);
        }
    }

    public void AtackUnit(Unit trg){                   //атака 1 юнита
        //перемещает всех выбранных юнитов в точку(можно переместить 1 юнита)
        //moves all selected units to the point (can move 1 unit)
        foreach(Unit unit in this.GetComponent<SelectUnits>().SelectedUnist ){
            unit.Atack(trg);
        }
    }

    void Update(){
        
    }


}
