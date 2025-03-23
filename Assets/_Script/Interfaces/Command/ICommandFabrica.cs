using UnityEngine;

public interface ICommandFabrica
{
    
    public bool CreateCommand(ref ICommand output, IEntity ent);
}
