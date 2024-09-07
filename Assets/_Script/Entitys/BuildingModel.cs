using UnityEngine;

public abstract class BuildingModel : Entity
{
    [SerializeField] protected int[] CellsXY = new int[2];
}
