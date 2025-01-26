using System;
using System.Collections.Generic;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit:MonoBehaviour, IPointerClickHandler, ISubjectUnitsClick
{
    protected Outline outline;
    protected Vector3 MoveCord; 
    protected EntityCfg Characteristics;

    private List<IObserverUnitsClick> _observers = new();
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){
        //для обработки клика на юнит//to handle clicks on a unit
        if(Input.GetKey(KeyCode.LeftShift)){ //добавляет юнитов с спмсок выбранных только с зажатым LShift
            if(eventData.button==PointerEventData.InputButton.Left){
                NotifyObserversAboutClickLeftShift();
            }
            return;
        }
        if(eventData.button==PointerEventData.InputButton.Left){
                NotifyObserversAboutClickLeft();
        }
    }
    
    public void AttachObserverUnitsClick(IObserverUnitsClick observer){
        _observers.Add(observer);
    }

    public void DetachObserverUnitsClick(IObserverUnitsClick observer){
        if(_observers.Contains(observer)){
            _observers.Remove(observer);
        }
    }

    public void NotifyObserversAboutClickLeft(){
        foreach(IObserverUnitsClick obs in _observers){obs.ClickOnUnitLeft(this);}
    }

    public void NotifyObserversAboutClickLeftShift(){
        foreach(IObserverUnitsClick obs in _observers){obs.ClickOnUnitShift(this);}
    }
    
    public  void Move(Vector3 cord){ //юнит всегда идет к заданной точке, это метод устанавливает эту точку
        MoveCord = cord;
    }

    public void OffOutline(){ 
       outline.OutlineWidth = 0.0f; //выключит обводку
    }
    public void OnOutline(){ //включит обводку
        outline.OutlineWidth = 5f; 
    }

    public abstract void AtackUnit(ref Unit target);
    public abstract void AtackBuild(ref Build target);

   void Awake(){
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0.0f;
        MoveCord = transform.position;

        GameObject.Find("CONTROLLERS").GetComponent<SelectedUnitsController>().SubscribeUnitsClick(this);
   }
    

    public void Update(){
        transform.position = Vector3.MoveTowards(transform.position, MoveCord, (float)(Characteristics.SP*Time.deltaTime));
    }
}
