using UnityEngine;

using  System.Collections.Generic;


/// <summary>
/// хранит в себе данные, которые могут понадобиться разным модулям
/// (конфига тут нет, к нему обрашаться напрямую)
/// ИЗБЕГАТЬ ТОГО, ЧТОБЫ РАЗНЫЕ МОДУЛИ МЕНЯЛИ 1 ПОЛЕ
/// </summary>




public class GlobalGameDataModel: MonoBehaviour{


    public int FractionId;
    public HashSet<Unit> AllUnits = new();
    public HashSet<Build> AllBuilds = new();
}
