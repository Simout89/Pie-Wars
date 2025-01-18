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
    
    private  List<GameObject> _unitsList = new(); //все юниты//all units
    private  List<GameObject> _buildList = new(); //все здания//all builds

    private void AddUnit(GameObject unt){
        _unitsList.Add(unt);
    }
    private void AddBuild(GameObject bld){
        _buildList.Add(bld);
    }

    public void SpawnUnit(Vector3 pos, int unit_id){
        GameObject unt = Instantiate(EntityPrefabs[unit_id], pos, Quaternion.identity);
        AddUnit(unt);
    }

    public void SpawnBuild(Vector3 pos, int build_id){
        GameObject bld = Instantiate(EntityPrefabs[build_id], pos, Quaternion.identity);
        AddBuild(bld);
    }
    
    public void Update(){
        
    }

}
