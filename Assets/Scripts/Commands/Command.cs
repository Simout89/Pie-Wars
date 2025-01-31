using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// юниты будут иметь список комманд и будут выполнять их друг за другом
/// после выполнения команда будет удаляться из списка
/// инициатором комманды будет юнит
/// комманда будет исполнять сама себя, вызывая методы юнита
/// создавать комманды будет скрип, который обрабатывает нажатия
/// </summary>



public abstract class Command
{
    protected IEntity _entity;
    protected object _target;
    private Unit unt;

    public Command(IEntity ent, object target){
        this._entity = ent;
        this._target = target;
    }

   

    public abstract bool Execute(); //выполнить комманду
    public abstract void Undo(); //отмена команды
    
}
