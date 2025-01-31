
using UnityEngine;
using UnityEngine.EventSystems;



public interface IEntity: ISubjecEntityClick, IPointerClickHandler
{

    Transform transform { get;}
    EntityCfg _characteristics{ get;}
    abstract bool ExecuteCommand(Command command);
    abstract void AddCommand(Command command);
    abstract void ClearCommandList();

    abstract void AddOutline();
    abstract void OnOutline();
    abstract void OffOutline();

    abstract void InitCharacteristics();
    
}