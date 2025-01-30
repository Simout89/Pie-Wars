using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class SelectedEntitysController : MonoBehaviour, IObserverEntityClick, IObserverMap
{
    /// <summary>
    /// принимает и обрабатывает пользовательский ввод
    /// </summary>
    
    public SelectedEntitysView _view;
    public SelectedEntitysModel _model;

    private List<IEntity> unitsInRect = new();

    [SerializeField] private UIService uiService;
    [SerializeField] private ObjectInRect objectInRect;

    [SerializeField] private MapClickHendler mapClickHendler;
    [SerializeField] private ObjectsPoolData objectsPoolData;
    

    private Color RectColor; //цвет для спрайта, меняется в зависимости от фракции

    [SerializeField] private bool isSelecting = false;


    [SerializeField] private Vector2 startPoint;
    [SerializeField] private Vector2 endPoint;

    
    public void ClickOnEntityLeft(object obj)
    {
        IEntity ent = (IEntity)obj;
        _model.AddNewSelectedUnit(ent);
        
    }

    public void ClickOnEntityLeftShift(object obj)
    {
        IEntity ent = (IEntity)obj;
        _model.AddSelectedUnit(ent);
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

    public void SubscribeEntitysClick(ISubjecEntityClick ent){      //подпишится на событие клик по юниту/
        ent.AttachObserverUnitsClick(this);
    }


    private void ClearUnitsInRect(){
        foreach(IEntity unt in unitsInRect){
            unt.OffOutline();
        }
        unitsInRect.Clear();
    }
    private void AddEntityInRect(IEntity ent){
        if(this.unitsInRect.Contains(ent)){

        }else{
            unitsInRect.Add(ent);
            ent.OnOutline();
        }
    }
    public void OnOunlineUnitsInRect(){
        foreach(IEntity ent in unitsInRect){
            ent.OnOutline();
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

            foreach(IEntity entity in objectsPoolData.AllUnitsInCameraSpace){

                if(objectInRect.PointInRect(entity._transformr.position, startPoint, endPoint)){
                    this.AddEntityInRect(entity);
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
