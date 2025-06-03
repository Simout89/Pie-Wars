using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


//отвечат за передвижение роем

public class MovmentRoy: IMovmentGroup
{

    private List<IEntity> _unitsList =  new();

    private List<IEntity> _activeUnits =  new();
    private List<IEntity> _completedUnits =  new();

    private List<ICommand> _commandList = new();    //список комманд, положенеи комманды в этом списке соответсвует положению юнита в стписке всех юнитов

    private Vector3 _target;

    public MovmentRoy(List<IEntity> entityList, Vector3 target){
        this._target = target;
        //this.isCompleted = false;

        foreach(IEntity ent in entityList){
            //if(ent.GetType() ==typeof(Unit)){
                ICommand moveCommand = new MoveCommand(ent,this._target);
                this._commandList.Add(moveCommand);
                this._activeUnits.Add(ent);
                this._unitsList.Add(ent);
                ent.AddCommand(moveCommand);
                
            //}
        }


    }

    public void RotationUnit(IEntity ent){
        ent.transform.LookAt(this._target);
    }

    public void RemoveEntityFromGroup(IEntity ent){

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

    public bool isCompleted(){
        return this._activeUnits.Count<=0;
    }

    public bool EntityInGroup(IEntity ent){
        return this._unitsList.Contains(ent);
    }

    public void Update(){
        int entId = 0;
        IEntity activeEnt;

        if(this._activeUnits.Count<=0){
            return;
        }

        for(int ind=0;ind<this._activeUnits.Count;ind++){
            activeEnt = this._activeUnits[ind];
            entId = this._unitsList.IndexOf(activeEnt);

            // СТАРЫЙ КОД с точным сравнением позиций:
            // if(activeEnt.transform.position == this._target){
        
            // ИСПРАВЛЕННЫЙ КОД с проверкой расстояния:
            float distanceToTarget = Vector3.Distance(activeEnt.transform.position, this._target);
        
            if(distanceToTarget <= 1.0f){
                activeEnt.RemoveCommand(this._commandList[entId]);
                this._completedUnits.Add(activeEnt);
                this._activeUnits.Remove(activeEnt);
                continue;
            }

            if(this._completedUnits.Count != 0){
                for(int i = 0; i < this._completedUnits.Count; i++){
                    float distanceToCompleted = Vector3.Distance(activeEnt.transform.position, this._completedUnits[i].transform.position);
                
                    if(distanceToCompleted <= 6.0f){
                        activeEnt.RemoveCommand(this._commandList[entId]);
                        this._completedUnits.Add(activeEnt);
                        this._activeUnits.Remove(activeEnt);
                        break;
                    }
                }
            }
        }
    } 


    
}
