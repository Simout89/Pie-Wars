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
    
    public void OnPointerClick(PointerEventData eventData){
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

        if(eventData.button==PointerEventData.InputButton.Left){ 
            Debug.Log(GetClickPos());
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 GetClickPos(){ //определит позицию клика
        Vector3 pos = new();
        RaycastHit hit;
        Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            pos = hit.point;
            Debug.Log("Click map");
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
        //Vector3
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch (Mode)
            {
                case -1:
                    this.GetComponent<SelectUnits>().ClearSelectedUnits();
                    Debug.Log("Click in mode -1");
                    break;
                case 0:
                    if(EntityId==-1){
                        Mode = -1;
                        break;
                    }else{
                        this.GetComponent<Spawner>().SpawnUnit(GetClickPos(),EntityId);
                        Mode = -1;
                        SetEntityId(-1);
                        break;
                    }
                    //Debug.Log("Click in mode 0");
                    
                case 1:
                    this.GetComponent<SelectUnits>().ClearSelectedUnits();
                    break;
                case 2:
                    Debug.Log("Click in mode 2");
                    break;
                case 3:
                    Debug.Log("Click in mode 3");
                    Mode = -1;
                    break;
                case 4:
                    Debug.Log("Click in mode 4");
                    Mode = -1;
                    break;

                default:
                    break;
            } 
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            this.GetComponent<UnitControl>().MoveUnits(GetClickPos(),ref this.GetComponent<SelectUnits>().SelectedUnist);
        }


    }
}
