using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsController : MonoBehaviour, IObserverEntitys, IObserverMap
{
    /// <summary>
    /// принимает пользовательский ввод
    /// </summary>
    
    private SelectedUnitsView _view;
    private SelectedUnitsModel _model;

    private bool isSelecting = false;

    private Vector3 startPoint;
    private Vector3 endPoint;


    public void ClickOnEntitysLeft(object obj)
    {
        Unit unt = (Unit)obj;
         _model.AddNewSelectedUnit(unt);
    }

    public void ClickOnEntitysShift(object obj)
    {
        Unit unt = (Unit)obj;
        _model.AddSelectedUnit(unt);
    }

    public void ClickOnMapLeft()
    {
        if(isSelecting!=true){
            _model.ClearSelectedUnits();
        }
    }

    public void ClickOnMapRight(Vector3 position){ //в данный момент не реализуется
        //Debug.Log("Click on map");
    }

    public void Initialization(SelectedUnitsView view, SelectedUnitsModel model, MapClickHendler mapClickHendler){
        _view = view;
        _model = model;
        mapClickHendler.AttachObserver(this);
    }

    public void Update(){

        //if(Input.GetMouseButtonDown(0)){ //нажали лкм лкм
            //this.isSelecting = true;
            //this.startPoint = Input.mousePosition;
            //this.endPoint = Input.mousePosition;

        //}else if(Input.GetMouseButton(0)){  //зажали лкм
            //this.endPoint = Input.mousePosition;
        //}

    }
}
