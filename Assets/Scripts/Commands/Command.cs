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
    protected Unit _unit;
    protected object _target;
    private Unit unt;

    public Command(Unit unit, object target){
        this._unit = unit;
        this._target = target;
    }

    protected Command(Unit unt)
    {
        this.unt = unt;
    }

    public abstract bool Execute(); //выполнить комманду
    public abstract void Undo(); //отмена команды
    
}
