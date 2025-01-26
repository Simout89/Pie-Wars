using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsModel : MonoBehaviour
{
    /// <summary>
    /// вся логика
    /// </summary>


    [SerializeField] private List<Unit> SelectedUnits = new();//выбраные сейчас юниты
    [SerializeField] private HashSet<Unit> SelectedBuilds = new();//выбраные сейчас зданий




    public void AddSelectedUnit(Unit unt){
        if(this.SelectedUnits.Contains(unt)){

        }else{
            SelectedUnits.Add(unt);
            unt.OnOutline();
        }
    }
    public void AddNewSelectedUnit(Unit unt){

        foreach(Unit unit in SelectedUnits){
            unit.OffOutline();
        }
        ClearSelectedUnits();
        SelectedUnits.Add(unt);
        //historyActionController.AssSelectedUnitsInHistory(SelectedUnits);
        unt.OnOutline();
    }

    public void SetNewSelectedUnitList(List<Unit> unitList){            //при выделение новых юнитов
        //Debug.Log(unitList.Count);
        this.SelectedUnits = new(unitList);
        //historyActionController.AssSelectedUnitsInHistory(SelectedUnits);
        Debug.Log("Set");
    }

     public void SetOldSelectedUnitList(List<Unit> unitList){            //при выборе юнитов, которые были выделены ранее
        
        this.SelectedUnits = unitList;

        
        foreach(Unit unt in unitList){
            unt.OnOutline();
        }
        
    }

    

    public void ClearSelectedUnits(){

        foreach(Unit unit in SelectedUnits){
            unit.OffOutline();
        }
        SelectedUnits.Clear();
        Debug.Log("Clear");
    }

}
