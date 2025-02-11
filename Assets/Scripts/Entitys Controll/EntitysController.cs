using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// система отвечающая за управление юнитами игроком. В автоматическом режиме юниты сами будут искать цель для атаки 
/// создает комманду на перемещение
/// создает комманду на атаку
/// содержит в себе модули, отвечающие за передвижение группы строем и роем
/// </summary>



public class EntitysController : MonoBehaviour
{
    [SerializeField] private SelectedEntitysModel _selectedEntitysModel;

    [SerializeField] private ICommand _actualCommand;

    private List<MovmentRoy> _movmentRoyGroups = new() ;

    private List<ICommand> _commandsList;


    private void OnEnable(){
        MapClickHendler.ClickOnMapRight += Move;
    }

    private void OnDisable(){
        MapClickHendler.ClickOnMapRight -= Move;
       
    }

    private void MovmentRoyController(){        //вызывется каждый кадр

        if(this._movmentRoyGroups.Count == 0 || this._movmentRoyGroups==null){

        }
        else{
            MovmentRoy group;
            for(int i=0;i<this._movmentRoyGroups.Count;i++){
                group = this._movmentRoyGroups[i];
                group.Update();
                if(group.isCompleted()){
                    this._movmentRoyGroups.Remove(group);
                }
                else{
                   // group.Update();
                }
            }
        }

    }

    private void Move(Vector3 target){

        //foreach(IEntity ent in this._selectedEntitysModel.SelectedEntitys){
            //ent.ClearCommandList();
            //ent.AddCommand(new MoveCommand(ent, target));
        //}

        if(this._selectedEntitysModel.SelectedEntitys.Count!=0){
            this._movmentRoyGroups.Add(new MovmentRoy(this._selectedEntitysModel.SelectedEntitys, target));
        }


    }




    public bool GiveCommand(ICommandFabrica commandFabrica){       //очистит список комманд у выделенных юнитов и добавит им новую
        bool result = false;

        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys){
            if(commandFabrica.CreateCommand(ref _actualCommand,ent)){result = true;}
            Debug.Log(_actualCommand);
            ent.ClearCommandList();
            ent.AddCommand(_actualCommand);
        }
        return result;


    }

    public bool AddCommand(ICommandFabrica commandFabrica){//добавить юнитам комманду, создаст комманду
        bool result = false;
        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys){
            if(commandFabrica.CreateCommand(ref _actualCommand,ent)){result = true;}
            ent.AddCommand(_actualCommand);
        }
        return result;
        
    }



     public bool GiveCommand(ICommand command){       //очистит список комманд у выделенных юнитов и добавит им новую(передается готовая)
        bool result = true;

        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys){
            ent.ClearCommandList();
            ent.AddCommand(command);
        }
        return result;


    }

    public bool AddCommand(ICommand command){//добавить юнитам комманду, создаст комманду
        bool result = true;
        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys){
            
            ent.AddCommand(command);
        }
        return result;
        
    }

    public void Update(){
        this.MovmentRoyController();
    }


}
