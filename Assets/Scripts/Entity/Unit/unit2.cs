// using System;
// using System.Collections.Generic;

// //using System.Numerics;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.EventSystems;


// //базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
// public abstract class Unit2:MonoBehaviour, IPointerClickHandler, ISubjectUnitsClick
// {
//     protected Outline outline;
//     protected Vector3 MoveCord; 
//     public EntityCfg Characteristics;

//     protected List<Command> _commandList = new();

//     private List<IObserverUnitsClick> _observers = new();
//     public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){
//         //для обработки клика на юнит//to handle clicks on a unit
//         if(Input.GetKey(KeyCode.LeftShift)){ //добавляет юнитов с спмсок выбранных только с зажатым LShift
//             if(eventData.button==PointerEventData.InputButton.Left){
//                 NotifyObserversAboutClickLeftShift();
//             }
//             return;
//         }
//         if(eventData.button==PointerEventData.InputButton.Left){
//                 NotifyObserversAboutClickLeft();
//         }
//     }
    
//     public void AttachObserverUnitsClick(IObserverUnitsClick observer){
//         _observers.Add(observer);
//     }

//     public void DetachObserverUnitsClick(IObserverUnitsClick observer){
//         if(_observers.Contains(observer)){
//             _observers.Remove(observer);
//         }
//     }

//     public void NotifyObserversAboutClickLeft(){
//         foreach(IObserverUnitsClick obs in _observers){obs.ClickOnUnitLeft(this);}
//     }

//     public void NotifyObserversAboutClickLeftShift(){
//         foreach(IObserverUnitsClick obs in _observers){obs.ClickOnUnitShift(this);}
//     }
    

//     public void OffOutline(){ 
//        outline.OutlineWidth = 0.0f; //выключит обводку
//     }
//     public void OnOutline(){ //включит обводку
//         outline.OutlineWidth = 5f; 
//     }

//     public void AddCommand(Command command){
//         _commandList.Add(command);
//     }
//     public void ClearCommandList(){
//         _commandList.Clear();
//     }



//     void Awake(){
//         outline = gameObject.AddComponent<Outline>();

//         outline.OutlineMode = Outline.Mode.OutlineAll;
//         outline.OutlineColor = Color.yellow;
//         outline.OutlineWidth = 0.0f;
//         MoveCord = transform.position;

//         GameObject.Find("CONTROLLERS").GetComponent<SelectedUnitsController>().SubscribeUnitsClick(this);
//     }

//     public void Update(){//постоянно выполняет комманды

//         foreach(Command command in _commandList){
//             if(command.Execute()){ //если команда исполнена
//                 _commandList.Remove(command);
//             }
//         }
//     }

   

// }