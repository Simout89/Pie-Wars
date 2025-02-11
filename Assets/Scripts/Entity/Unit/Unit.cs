using System;
using System.Collections.Generic;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit:MonoBehaviour, IEntity
{
    protected Outline outline;

    public EntityCfg Characteristics;

    private List<IObserverEntityClick> _observers = new();

    protected List<ICommand> _commandList = new();

    public Transform transformr { 
        get {return transform;} 
    }
    public EntityCfg _characteristics { 
        get {return Characteristics;}
       
    }

    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){

        //для обработки клика на юнит//to handle clicks on a unit
        if(Input.GetKey(KeyCode.LeftShift)){ //клик по юниту лкм+shift
             if(eventData.button==PointerEventData.InputButton.Left){
                NotifyObserversAboutClickLeftShift();
            }
             return;
        }
        if(eventData.button==PointerEventData.InputButton.Left){//клик по юниту лкм
                NotifyObserversAboutClickLeft();
        }



    }

    public bool ExecuteCommand(ICommand command){
        return command.Execute();
    }

    public void AddCommand(ICommand command){
        _commandList.Add(command);
    }

    public void RemoveCommand(ICommand command){
        this._commandList.Remove(command);
    }

    public void ClearCommandList(){
        _commandList.Clear();
    }

    public void AddOutline(){
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0.0f;
    }

    public void OnOutline(){
        outline.OutlineWidth = 5f;
    }

    public void OffOutline(){
        outline.OutlineWidth = 0.0f;
    }

    public void InitCharacteristics(){
        throw new NotImplementedException();
    }

    public void AttachObserverUnitsClick(IObserverEntityClick observer){
        _observers.Add(observer);
    }

    public void DetachObserverUnitsClick(IObserverEntityClick observer){
        if(_observers.Contains(observer)){
            _observers.Remove(observer);
        }
    }

    public void NotifyObserversAboutClickLeft(){
        foreach(IObserverEntityClick obs in _observers){obs.ClickOnEntityLeft(this);}
    }

    public void NotifyObserversAboutClickLeftShift(){
        foreach(IObserverEntityClick obs in _observers){obs.ClickOnEntityLeftShift(this);}
    }

    public void Move(Vector3 target){

        transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);//(float)this.Characteristics.SP);
    }


    public void Awake(){
        this.AddOutline();
        GameObject.Find("CONTROLLERS").GetComponent<SelectedEntitysController>().SubscribeEntitysClick(this);
    }

    public void Update(){
        if(this._commandList.Count!=0){
           
           
            //foreach(ICommand command in this._commandList){
                if(this._commandList[0].Execute()){      //КОММАНДА ВЫПОЛНИЛАСЬ
                    this._commandList.Remove(this._commandList[0]); 
                }
                
            //}

        }

    }

   
}
