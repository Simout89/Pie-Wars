using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class SelectedUnitsController : MonoBehaviour, IObserverUnitsClick, IObserverMap
{
    /// <summary>
    /// принимает и обрабатывает пользовательский ввод
    /// </summary>
    
    public SelectedUnitsView _view;
    public SelectedUnitsModel _model;

    private List<Unit> unitsInRect = new();

    [SerializeField] private UIService uiService;
    [SerializeField] private ObjectInRect objectInRect;

    [SerializeField] private MapClickHendler mapClickHendler;
    [SerializeField] private ObjectsPoolData objectsPoolData;
    

    private Color RectColor; //цвет для спрайта, меняется в зависимости от фракции

    [SerializeField] private bool isSelecting = false;


    [SerializeField] private Vector2 startPoint;
    [SerializeField] private Vector2 endPoint;

    
    public void ClickOnUnitLeft(object obj)
    {
        Unit unt = (Unit)obj;
        _model.AddNewSelectedUnit(unt);
        
    }

    public void ClickOnUnitShift(object obj)
    {
        Unit unt = (Unit)obj;
        _model.AddSelectedUnit(unt);
    }

    public void ClickOnMapLeft()    
    {
        if(this.startPoint == this.endPoint){
            _model.ClearSelectedUnits();    
        }else{
            return;
        }
    }

    public void ClickOnMapRight(Vector3 position){ //в данный момент не реализуется
    }

    public void SubscribeUnitsClick(ISubjectUnitsClick unt){      //подпишится на событие клик по юниту/
        unt.AttachObserverUnitsClick(this);
    }

    public void Initialization(SelectedUnitsView view, SelectedUnitsModel model, MapClickHendler mapClickHendler){
        _view = view;
        _model = model;
        mapClickHendler.AttachObserverMap(this);
    }

    private void ClearUnitsInRect(){
        foreach(Unit unt in unitsInRect){
            unt.OffOutline();
        }
        unitsInRect.Clear();
    }
    private void AddUnitsInRect(Unit unt){
        if(this.unitsInRect.Contains(unt)){

        }else{
            unitsInRect.Add(unt);
            unt.OnOutline();
        }
    }
    public void OnOunlineUnitsInRect(){
        foreach(Unit unt in unitsInRect){
            unt.OnOutline();
        }
    }

    public void Awake(){
        this.mapClickHendler.AttachObserverMap(this);
    }

    public void Update(){

        if(Input.GetMouseButtonDown(0)){ //нажали лкм лкм
            this.ClearUnitsInRect();
            this.isSelecting = true;
            this.startPoint = Input.mousePosition;
            this.endPoint = Input.mousePosition;

        }else if(Input.GetMouseButton(0)){  //зажали лкм
            this.endPoint = Input.mousePosition;

        }else if(Input.GetMouseButtonUp(0)){
            this.isSelecting = false;
            this.endPoint = Input.mousePosition;

            if(startPoint!=endPoint){
                _model.SetNewSelectedUnitList(unitsInRect);
                OnOunlineUnitsInRect();
            }
          
        }

        if(isSelecting){
            Rect rectInCanvans = this.uiService.GetUIRectByScreenPoints(this.startPoint, this.endPoint);
            
            this._view.SetPositions(rectInCanvans);
            this._view.SetVisible(true);
            this.ClearUnitsInRect();

            foreach(Unit unit in objectsPoolData.AllUnitsInCameraSpace){

                if(objectInRect.PointInRect(unit.transform.position, startPoint, endPoint)){
                    AddUnitsInRect(unit);
                }//else{
                    
                    //if(this.unitsInRect.Contains(unit)){
                            //unitsInRect.Remove(unit);
                            //unit.OffOutline();
                    //}
                    
                //}
            }


        }else{
            _view.SetVisible(false);
        }
    }
}
