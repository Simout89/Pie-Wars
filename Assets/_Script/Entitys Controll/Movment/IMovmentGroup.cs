using UnityEngine;

public interface IMovmentGroup
{
    
    abstract void RotationUnit(IEntity ent);
    abstract void RemoveEntityFromGroup(IEntity ent);
    abstract bool isCompleted();
    abstract bool EntityInGroup(IEntity ent);
    abstract void Update();

}
