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
    [SerializeField] private HashSet<Unit>AllUnits = new();  //все
    private HashSet<Build>AllBuilds = new();

    [SerializeField] public List <Unit>AllUnitsInCameraSpace = new();         //юниты и здания, попадающие в область видимости игрока
    private HashSet<Build>AllBuildsInCameraSpace = new();


}
