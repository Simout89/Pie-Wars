using UnityEngine;

public class HarvestCommandFabrica : ICommandFabrica
{
    private ResourceNode _targetNode;

    public HarvestCommandFabrica(ResourceNode targetNode)
    {
        _targetNode = targetNode;
    }

    public bool CreateCommand(ref ICommand output, IEntity ent)
    {
        if(_targetNode != null && !_targetNode.IsEmpty)
        {
            output = new HarvestCommand(ent, _targetNode);
            return true;
        }
        return false;
    }
}