
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;



public interface IEntity: ISubjecEntityClick, IPointerClickHandler
{
    public int TeamId { get; set; }
    Transform transform { get;}
    EntityCfg _characteristics{ get;}

    public List<SkillBase> skills { get; set; }
    public string Name { get; set; }
    abstract bool ExecuteCommand(ICommand command);
    abstract void AddCommand(ICommand command);
    abstract void RemoveCommand(ICommand command);
    abstract void ClearCommandList();

    abstract void AddOutline();
    abstract void OnOutline();
    abstract void OffOutline();

    abstract void Move(Vector3 target);

    abstract void InitCharacteristics();
    
}