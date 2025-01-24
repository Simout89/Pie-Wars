using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsModel : MonoBehaviour
{
    /// <summary>
    /// вся логика
    /// </summary>

    private GlobalGameDataModel _globalGameData;

    private HashSet<Unit> SelectedUnits = new();//выбраные сейчас юниты
    private HashSet<Unit> SelectedBuilds = new();//выбраные сейчас зданий



    public void AddSelectedUnit(Unit unt){
        SelectedUnits.Add(unt);
    }
    public void AddNewSelectedUnit(Unit unt){
        ClearSelectedUnits();
        SelectedUnits.Add(unt);
    }

    public void ClearSelectedUnits(){
        SelectedUnits.Clear();
    }

    public bool IfUnitInRect(Rect rect){
        
        bool result = false;

        return result;
    }


}
