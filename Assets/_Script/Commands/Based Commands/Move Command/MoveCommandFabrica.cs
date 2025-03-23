using UnityEngine;

public class MoveCommandFabrica : ICommandFabrica
{
    public MoveCommandFabrica(){

    }

    public bool CreateCommand(ref ICommand output, IEntity ent)
    {
       //output = new MoveCommand(ent, (Vector3)(target));
        return true;
    }

}
