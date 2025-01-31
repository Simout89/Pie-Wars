using UnityEngine;



public class MoveCommand : Command
{
    public MoveCommand(IEntity ent, object target) : base(ent, target)
    {
    }

    public override bool Execute()
    {
        bool isMoveig = true;
        Vector3 target = (Vector3)_target;
        while(isMoveig){
            if(_entity.transform.position == target){
                isMoveig = false; //юнит достиг точки
            }else if(_entity.transform.position != target){
                _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, target, (float)(_entity._characteristics.SP*Time.deltaTime));
            }
        }
        return true;//комманда завершилавсь

    }

    public override void Undo()
    {

    }
}
