using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// хранит данные для для ObjectsPoolModel
/// хранит всех юнитов
/// хранит все здания
/// хранит всех юнитов, попадающих в пространство камеры
/// хранит всех здания, попадающие в пространство камеры
/// </summary>

public class ObjectsPoolData : MonoBehaviour
{
    [SerializeField] public HashSet<Unit>AllUnits = new();  //все
    [SerializeField] private HashSet<Build> AllBuilds = new();

    [SerializeField] public List <Unit>AllUnitsInCameraSpace = new();         //юниты и здания, попадающие в область видимости игрока
    private HashSet<Build>AllBuildsInCameraSpace = new();


    public void AddBuild(Build bld)
    {
        this.AllBuilds.Add(bld);
    }
    public void AddUnit(Unit unt)
    {
        
        this.AllUnits.Add(unt);
        this.AllUnitsInCameraSpace.Add(unt);
        
    }


}
