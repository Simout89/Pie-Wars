
using UnityEngine;

public class MoveCommand :ICommand {
    private Vector3 _target;

    public IEntity _entity { get; set;}


    public MoveCommand(IEntity ent, Vector3 target)
    {
        this._entity = ent;
        this._target = target;
    }

    public bool Execute()
    {
        if(this._entity.transform.position != this._target){
            this._entity.Move(this._target);
            //Debug.Log("Move");
            return false;
        }else{
            return true;
        }
    }
}
