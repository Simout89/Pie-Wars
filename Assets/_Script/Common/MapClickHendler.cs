using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapClickHendler : MonoBehaviour, IPointerClickHandler, ISubjectMap
{
    public Camera _Camera;
    private List<IObserverMap> _observers = new();

    public static event Action<UnityEngine.Vector3> ClickOnMapRight;

    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("click left");
            NotifyObserversAboutClickLeft();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            NotifyObserversAboutClickRight();
            Debug.Log("click right");
            ClickOnMapRight?.Invoke(GetClickPosition());
        }
    }

    public void AttachObserverMap(IObserverMap observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserverMap(IObserverMap observer)
    {
        if(_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObserversAboutClickLeft()
    {
        foreach(IObserverMap obs in _observers){obs.ClickOnMapLeft();}
    }

    public void NotifyObserversAboutClickRight()
    {
        foreach(IObserverMap obs in _observers){obs.ClickOnMapRight(GetClickPosition());}
    }

    public UnityEngine.Vector3 GetClickPosition()
    {
        UnityEngine.Vector3 pos = new();
        RaycastHit hit;
        Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            pos = hit.point;
        }
        return pos;
    }

    void Awake()
    {
       
    }
}