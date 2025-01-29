using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsModel : MonoBehaviour
{
    /// <summary>
    /// вся логика
    /// </summary>

    [SerializeField] private HistorySelectedData _historySelectedData;

    [SerializeField] public List<Unit> SelectedUnits = new();//выбраные сейчас юниты
    [SerializeField] private HashSet<Unit> SelectedBuilds = new();//выбраные сейчас зданий




    public void AddSelectedUnit(Unit unt){
        if(this.SelectedUnits.Contains(unt)){

        }else{
            SelectedUnits.Add(unt);
            unt.OnOutline();
            _historySelectedData.NewRecordInHistory(SelectedUnits);
        }
    }
    public void AddNewSelectedUnit(Unit unt){
        ClearSelectedUnits();
        SelectedUnits.Add(unt);

        foreach(Unit unit in SelectedUnits){
            unit.OnOutline();
        }
        _historySelectedData.NewRecordInHistory(SelectedUnits);
    }

    public void SetNewSelectedUnitList(List<Unit> unitList){            //при выделение новых юнитов
        this.ClearSelectedUnits();
        this.SelectedUnits = new(unitList);
        _historySelectedData.NewRecordInHistory(SelectedUnits);
    }

     public void SetOldSelectedUnitList(List<Unit> unitList){            //при выборе юнитов, которые были выделены ранее
        this.ClearSelectedUnits();
        if(unitList==null || unitList.Count == 0){
            Debug.Log("null");
        }else{
            Debug.Log("Not null");
            this.SelectedUnits = new(unitList);
            foreach(Unit unt in SelectedUnits){
                unt.OnOutline();
            }
        }
    }

    

    public void ClearSelectedUnits(){

        foreach(Unit unit in SelectedUnits){
            unit.OffOutline();
        }
        SelectedUnits.Clear();

    }

}
