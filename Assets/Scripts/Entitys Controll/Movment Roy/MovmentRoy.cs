using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


//отвечат за передвижение роем

public class MovmentRoy
{

    private List<IEntity> _unitsList =  new();

    private List<IEntity> _activeUnits =  new();
    private List<IEntity> _completedUnits =  new();

    private List<ICommand> _commandList = new();    //список комманд, положенеи комманды в этом списке соответсвует положению юнита в стписке всех юнитов

    private Vector3 _target;

    public MovmentRoy(List<IEntity> entityList, Vector3 target){
        this._target = target;

        foreach(IEntity ent in entityList){
            //if(ent.GetType() ==typeof(Unit)){
                ICommand moveCommand = new MoveCommand(ent,this._target);
                this._commandList.Add(moveCommand);
                this._activeUnits.Add(ent);
                this._unitsList.Add(ent);
                ent.AddCommand(moveCommand);
            //}
        }
        //Debug.Log(_commandList.Count);


    }

    public bool isCompleted(){
        return this._activeUnits.Count<=0;
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
            
            if(activeEnt.transform.position == this._target){

                activeEnt.RemoveCommand(this._commandList[entId]);
                this._completedUnits.Add(activeEnt);
                this._activeUnits.Remove(activeEnt);
                continue;
                
            }

            if(this._completedUnits.Count !=0){
                for(int i = 0; i<this._completedUnits.Count;i++){

                    if(Vector3.Distance(activeEnt.transform.position,this._completedUnits[i].transform.position)<=10.0f){

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
