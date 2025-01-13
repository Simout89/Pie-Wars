using System;
using UnityEngine;
using UnityEngine.EventSystems;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit:BasedEntityClass, IPointerClickHandler
{
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){
        //для обработки клика на юнит//to handle clicks on a unit
        //добавит его с список выбранных юнитов//will add it to the list of selected units
        if(eventData.pointerId==-1){
            Debug.Log("Click obj");
        }

    }

    
    public Unit(int enity_id) : base(enity_id) { 

    }

    public override void Spawn(Vector3 cord){

    }
    public override void Move(Vector3 cord){

    }
}
