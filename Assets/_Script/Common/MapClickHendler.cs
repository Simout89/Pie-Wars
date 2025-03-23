using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// отвечает за обработку кликов по карте
/// считывает точку, куда должны двигаться юниты
/// очищает список выбранных юнитов при клике пкм по карте
/// определяет позицию для строительства здания
/// </summary>
public class MapClickHendler : MonoBehaviour, IPointerClickHandler, ISubjectMap
{
    public Camera _Camera;
    private List<IObserverMap> _observers = new();

    public static event Action<UnityEngine.Vector3> ClickOnMapRight;




    
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){

        if(eventData.button==PointerEventData.InputButton.Left){
            NotifyObserversAboutClickLeft();
        }
        if(eventData.button==PointerEventData.InputButton.Right){
            NotifyObserversAboutClickRight();
            ClickOnMapRight?.Invoke(GetClickPosition());
        }
    }

    public void AttachObserverMap(IObserverMap observer){
        _observers.Add(observer);
    }

    public void DetachObserverMap(IObserverMap observer){
     if(_observers.Contains(observer)){
            _observers.Remove(observer);
        }
    }

    public void NotifyObserversAboutClickLeft(){
        foreach(IObserverMap obs in _observers){obs.ClickOnMapLeft();}
    }

    public void NotifyObserversAboutClickRight(){
        foreach(IObserverMap obs in _observers){obs.ClickOnMapRight(GetClickPosition());}
    }

    UnityEngine.Vector3 GetClickPosition(){ //определит позицию клика
        UnityEngine.Vector3 pos = new();
        RaycastHit hit;
        Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            pos = hit.point;
        }
        return pos;
    }

}
