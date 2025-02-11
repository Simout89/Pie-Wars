
using UnityEngine;

public class MoveCommand :ICommand {
    private IEntity ent;
    private Vector3 _target;

    public IEntity _entity { get; set;}


    public MoveCommand(IEntity ent, Vector3 target)
    {
        this.ent = ent;
        this._target = target;
    }

    public bool Execute()
    {
        if(this.ent.transform.position != this._target){
            this.ent.Move(this._target);
            return false;
        }else{
            return true;
        }
    }
}
