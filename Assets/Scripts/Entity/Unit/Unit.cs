using System;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit:MonoBehaviour, IPointerClickHandler
{
    private bool MoveMode=false;
    protected Outline outline;
    protected Vector3 MoveCord; 
    protected EntityCfg Characteristics;
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){
        //для обработки клика на юнит//to handle clicks on a unit
        //добавит его с список выбранных юнитов//will add it to the list of selected units
        if(Input.GetKey(KeyCode.LeftShift)){ //добавляет юнитов с спмсок выбранных только с зажатым LShift
            if(eventData.button==PointerEventData.InputButton.Left){
                GameObject.Find("System").GetComponent<SelectUnits>().AddInSelectedUnit(this);

                
                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.yellow;
                outline.OutlineWidth = 5f;                  //обводка объекта
            }
            return;
        }
        if(eventData.button==PointerEventData.InputButton.Left){
                GameObject.Find("System").GetComponent<SelectUnits>().ClearSelectedUnits();
                GameObject.Find("System").GetComponent<SelectUnits>().AddInSelectedUnit(this);
                
                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.yellow;
                outline.OutlineWidth = 5f; 
        }
    }
    //public void Start(){Debug.Log("123445");}
    
    
    public  void Move(Vector3 cord){
        //transform.position = Vector3.Lerp(transform.position, cord, 1 * Time.deltaTime);
        MoveMode = true;
        MoveCord = cord;
    }

    public void DelFromSelectetUnits(){   //вызывается при удаление юнита из списка выбранных
       outline.OutlineWidth = 0.0f; //удалит обводку

    }
   void Awake(){
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0.0f;
   }
    //public abstract void Spawn(Vector3 cord);
    public abstract void Atack(Unit target);
    public void Destroy(){

    }

    public void Update(){
        transform.position = Vector3.Lerp(transform.position, MoveCord,  Time.deltaTime);
    }
}
