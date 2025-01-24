using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsController : MonoBehaviour, IObserverEntitys, IObserverMap
{
    /// <summary>
    /// принимает пользовательский ввод
    /// </summary>
    
    public SelectedUnitsView _view;
    public SelectedUnitsModel _model;
    [SerializeField] private UIService uiService;

    private Color RectColor; //цвет для спрайта, меняется в зависимости от фракции

    private bool isSelecting = false;

    private Vector2 startPoint;
    private Vector2 endPoint;


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

    public void ClickOnMapLeft()    //в данный момент не реализуется
    {
        //if(isSelecting!=true){
            //_model.ClearSelectedUnits();
        //}
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

        if(Input.GetMouseButtonDown(0)){ //нажали лкм лкм
            this.isSelecting = true;
            this.startPoint = Input.mousePosition;
            this.endPoint = Input.mousePosition;

        }else if(Input.GetMouseButton(0)){  //зажали лкм
            this.endPoint = Input.mousePosition;
        }else if(Input.GetMouseButtonUp(0)){
            this.isSelecting = false;
            this.endPoint = Input.mousePosition;
        }

        if(isSelecting){

            Rect rect = this.uiService.GetUIRectByScreenPoints(this.startPoint, this.endPoint);
            
            this._view.SetPositions(rect);
            this._view.SetVisible(true);
        }else{
            _view.SetVisible(false);
        }


    }
}
