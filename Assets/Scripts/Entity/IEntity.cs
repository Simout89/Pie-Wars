
using UnityEngine;
using UnityEngine.EventSystems;



public interface IEntity: ISubjecEntityClick, IPointerClickHandler
{

    Transform transform { get;}
    EntityCfg _characteristics{ get;}
    abstract bool ExecuteCommand(ICommand command);
    abstract void AddCommand(ICommand command);
    abstract void ClearCommandList();

    abstract void AddOutline();
    abstract void OnOutline();
    abstract void OffOutline();

    abstract void InitCharacteristics();
    
}