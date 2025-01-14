using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;


/// <summary>
/// спвнит юнитов и здания//spawns units and buildings
/// хранит всех созданных юнитов и все созданные здания//stores all created units and all created buildings
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] EntityPrefabs= new GameObject[Constants.COUNT_ENTITY];//Список префабов юнитов и зданий//prefabs list
    
    private  List<GameObject> UnitsList = new(); //все юниты//all units

    void AddUnit(GameObject unt){
        UnitsList.Add(unt);
        Debug.Log(UnitsList[0]);
    }
    public void SpawnUnit(Vector3 pos, int unit_id){
        GameObject unt = Instantiate(EntityPrefabs[unit_id], pos, Quaternion.identity);
        AddUnit(unt);

    }
    
    public void Update(){
        
    }

}
