using System;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;




/// <summary>
/// отвечает за обработку кликов по карте
/// считывает точку, куда должны двигаться юниты
/// очищает список выбранных юнитов при клике пкм по карте
/// определяет позицию для строительства здания
/// </summary>
public class MapClickHendler : MonoBehaviour, IPointerClickHandler
{

    private int Mode = Constants.MODE_MAP_DEFAULT;
    private int EntityId = -1;//id юнита/здания которое надо заспвнить
    public Camera _Camera;
    
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){
        /// <summary>
        /// лкм - получить позицию клика на карте
        /// действия после получения клика зависят от текушего режима
        /// режимы:
        /// -1. режим по умолчанию
        /// 0. режим строительства, если этот режим активен, то на месте клика будет построенно здание/заспавнен юнит
        /// 1. режим ожидания приказа двигаться к точке
        /// 2. режим атаки: атаковать цель на точке клика(выпустить луч, определить с каким калайдером этот луч пересекается, атаковать объект с этим калайдером)
        /// 3. установка точки, куда будут идти рабочие юниты после спавна(можно реализовать в скрипте здания)
        /// 4. установка точки, куда будут идти боевые юниты после спавна(можно реализовать в скрипте здания)
        /// </summary>
        GameObject _System = GameObject.Find("System");
        if(Input.GetKey(KeyCode.LeftShift)){ 
            if(eventData.button==PointerEventData.InputButton.Left){

                if(Mode!=Constants.MODE_MAP_WAIT_FLAG_SOLIDER | Mode!=Constants.MODE_MAP_WAIT_FLAG_WORKER){

                }
                else{
                    _System.GetComponent<SelectUnits>().ClearSelectedUnits();
                    //System.GetComponent<SelectUnits>().ClearSelectOneUnit();
                    SetMapMode(Constants.MODE_MAP_DEFAULT);
                }
            }
        }
        if(eventData.button==PointerEventData.InputButton.Right){
            if(Mode==Constants.MODE_MAP_WAIT_TARGET){
                Vector3 target = GetClickPos();
                _System.GetComponent<UnitControl>().MoveUnits(target);
            }
                
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 GetClickPos(){ //определит позицию клика
        Vector3 pos = new();
        RaycastHit hit;
        Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            pos = hit.point;
        }
        return pos;
    }

    public void SetMapMode(int mode){
        Mode = mode;
    }
    public void SetEntityId(int entity_id){
        EntityId = entity_id;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
    }
}
