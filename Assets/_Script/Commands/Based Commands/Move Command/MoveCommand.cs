
using UnityEngine;

public class MoveCommand : ICommand {
    private Vector3 _target;
    private float _threshold = 0.1f; // порог достижения цели

    public IEntity _entity { get; set;}

    public MoveCommand(IEntity ent, Vector3 target)
    {
        this._entity = ent;
        this._target = target;
    }

    public bool Execute()
    {
        // СТАРЫЙ КОД:
        // if(this._entity.transform.position != this._target){
        
        // ИСПРАВЛЕННЫЙ КОД с проверкой расстояния:
        float distance = Vector3.Distance(this._entity.transform.position, this._target);
        
        if(distance > _threshold){
            this._entity.Move(this._target);
            return false; // команда еще выполняется
        }
        else{
            return true; // команда выполнена
        }
    }
}
