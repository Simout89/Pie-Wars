using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// спвнит юнитов и здания//spawns units and buildings
/// хранит всех созданных юнитов и все созданные здания//stores all created units and all created buildings
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] EntityPrefabs= new GameObject[Constants.COUNT_ENTITY];//Список префабов юнитов и зданий//prefabs list
    
    private  List<Unit> UnitsList = new(); //все юниты//all units
    
    void AddUnit(Unit unt){
        UnitsList.Add(unt);
    }
    
}
