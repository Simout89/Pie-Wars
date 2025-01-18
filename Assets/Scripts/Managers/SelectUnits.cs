using System.Collections.Generic;
using UnityEngine;


//отвечает за выбор юнитов областью, выбор юнитов по одному реализован в классе самого юнита 

public class SelectUnits : MonoBehaviour
{
    public List<Unit>SelectedUnist = new();

    //private List<Unit>AllUnits = new();
    private Unit SelectUnit; //выбранный сейчас юнит
    private MapClickHendler _mapClickHendler;
    
    void Start()
    {
        _mapClickHendler = GameObject.Find("Terrain").GetComponent<MapClickHendler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedUnist.Count>0){
            _mapClickHendler.SetMapMode(Constants.MODE_MAP_WAIT_TARGET);
        }
        
    }


    public void AddInSelectedUnit(Unit obj){ //добавит 1 юнита в список//will add 1 unit to the list
        SelectUnit = null;
        SelectedUnist.Add(obj);
    }
    public void ClearSelectedUnits(){

        foreach(Unit unit in this.GetComponent<SelectUnits>().SelectedUnist ){
            unit.DelFromSelectetUnits();
        }
        SelectedUnist.Clear();
    }
    public void SelectOneUnit(Unit obj){
        SelectUnit = obj;
    }
    public void ClearSelectOneUnit(){
        SelectUnit = null;
    }
}
