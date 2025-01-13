using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit:MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){
        //для обработки клика на юнит//to handle clicks on a unit
        //добавит его с список выбранных юнитов//will add it to the list of selected units
        if(eventData.button==PointerEventData.InputButton.Left){
            GameObject.Find("System").GetComponent<SelectUnits>().AddInSelectedUnit(this);
        }

    }
    //public void Start(){Debug.Log("123445");}
    protected EntityCfg Characteristics;
    public Unit(int enity_id){
        //this.Characteristics = Config.CfgData[enity_id_id];
        //this.Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[enity_id];

    }
    public  void Move(Vector3 cord){}
    //public abstract void Spawn(Vector3 cord);
    public abstract void Atack(BasedEntityClass target);
    public void Destroy(){

        
    }
}
