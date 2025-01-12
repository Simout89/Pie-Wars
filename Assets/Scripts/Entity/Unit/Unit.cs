using UnityEngine;



//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit:BasedEntityClass
{

    public Unit(int enity_id) : base(enity_id) { 

    }

    public override void Spawn(Vector3 cord){

    }
    public override void Move(Vector3 cord){

    }
}
