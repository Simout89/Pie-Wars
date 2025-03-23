using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MovmentFormation : IMovmentGroup
{

    private List<IEntity> _unitsList =  new();

    private List<IEntity> _activeUnits =  new();
    private List<IEntity> _completedUnits =  new();


    private List<ICommand> _commandList = new();    //список комманд, положенеи комманды в этом списке соответсвует положению юнита в стписке всех юнитов

    private Vector3 _target;
    Vector3 _centerPosition = new();

    public MovmentFormation(List<IEntity> entityList, Vector3 target){
        this._target = target;

        Vector3 offset = new();

        List<Vector3> pointsList = new();
        foreach(IEntity ent in entityList){
            pointsList.Add(ent.transform.position);
        }
        this._centerPosition = this.CalculateCenter(pointsList);
        
        foreach(IEntity ent in entityList){
            //if(ent.GetType() ==typeof(Unit)){
                offset = ent.transform.position - _centerPosition;
                ICommand moveCommand = new MoveCommand(ent,this._target+offset);
                this._commandList.Add(moveCommand);
                this._unitsList.Add(ent);
                this._activeUnits.Add(ent);
                ent.AddCommand(moveCommand);
                
            //}
        }
    }

    public Vector3 CalculateCenter(List<Vector3> pointsList){

        Vector3 result = Vector3.zero;

        foreach(Vector3 point in pointsList){
            result +=point;
        }
        return result / pointsList.Count;
    }



    public bool EntityInGroup(IEntity ent)
    {
        return this._unitsList.Contains(ent);
    }

    public bool isCompleted()
    {
        return this._activeUnits.Count<=0;
    }

    public void RemoveEntityFromGroup(IEntity ent)
    {
        int entId = this._unitsList.IndexOf(ent);
        this._unitsList.Remove(ent);
        ent.RemoveCommand(this._commandList[entId]);
        this._commandList.Remove(this._commandList[entId]);

        if(this._activeUnits.Contains(ent)){
            this._activeUnits.Remove(ent);
        }
        else{
            this._completedUnits.Remove(ent);
        }
    }

    public void RotationUnit(IEntity ent)
    {
        ent.transform.LookAt(this._target);
    }

    public void Update()
    {
        Vector3 offset = new();
        foreach(IEntity ent in this._activeUnits){
            offset = ent.transform.position - _centerPosition;
            if(ent.transform.position == this._target+offset){
                this._completedUnits.Add(ent);
                this._activeUnits.Remove(ent);
            }

        }
    }
}
