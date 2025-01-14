using System.Collections.Generic;
using UnityEngine;


//отвечает за выбор юнитов областью, выбор юнитов по одному реализован в классе самого юнита
public class SelectUnits : MonoBehaviour
{
    public List<Unit>SelectedUnist = new();
    private MapClickHendler MapClickHendler;
    
    void Start()
    {
        MapClickHendler = this.GetComponent<MapClickHendler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedUnist.Count>0){
            MapClickHendler.SetMapMode(Constants.MODE_MAP_WAIT_TARGET);
        }
        
    }

    public void AddInSelectedUnit(Unit obj){ //добавит 1 юнита в список//will add 1 unit to the list
        SelectedUnist.Add(obj);
    }

}
