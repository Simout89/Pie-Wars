
using UnityEngine;
using UnityEngine.EventSystems;



public interface IEntity: ISubjecEntityClick, IPointerClickHandler
{

    Transform transform { get;}
    EntityCfg _characteristics{ get;  }
    [SerializeField] int teamNum { get; set; }
    abstract bool ExecuteCommand(ICommand command);
    abstract void AddCommand(ICommand command);
    abstract void RemoveCommand(ICommand command);
    abstract void ClearCommandList();

    abstract void AddOutline();
    abstract void OnOutline();
    abstract void OffOutline();

    abstract void Move(Vector3 target);
    abstract void TakeDamage(double damage);

    abstract void InitCharacteristics();
    
}