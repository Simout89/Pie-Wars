using UnityEngine;



public class MoveCommand : Command
{
    public MoveCommand(Unit unit, object target) : base(unit, target)
    {
    }

    public override bool Execute()
    {
        bool isMoveig = true;
        Vector3 target = (Vector3)_target;
        while(isMoveig){
            if(_unit.transform.position == target){
                isMoveig = false; //юнит достиг точки
            }else if(_unit.transform.position != target){
                _unit.transform.position = Vector3.MoveTowards(_unit.transform.position, target, (float)(_unit.Characteristics.SP*Time.deltaTime));
            }
        }
        return true;//комманда завершилавсь

    }

    public override void Undo()
    {

    }
}
