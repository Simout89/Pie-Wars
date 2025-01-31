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
    protected Vector3 MoveCord; 
    public EntityCfg Characteristics;

    private List<IObserverEntityClick> _observers = new();

    protected List<Command> _commandList = new();

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

    public bool ExecuteCommand(Command command){
        return command.Execute();
    }

    public void AddCommand(Command command){
        _commandList.Add(command);
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


    public void Awake(){
        this.AddOutline();
        GameObject.Find("CONTROLLERS").GetComponent<SelectedEntitysController>().SubscribeEntitysClick(this);
    }

   
}
