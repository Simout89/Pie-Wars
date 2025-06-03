using System.Collections.Generic;
using _Script.SelectedEntitys;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

/// <summary>
/// система отвечающая за управление юнитами игроком. В автоматическом режиме юниты сами будут искать цель для атаки 
/// создает комманду на перемещение
/// создает комманду на атаку
/// содержит в себе модули, отвечающие за передвижение группы строем и роем
/// </summary>



public class EntitysController : MonoBehaviour
{
    [Inject] private SelectedEntitysModel _selectedEntitysModel;

    // ИСПРАВЛЕННОЕ СВОЙСТВО (было рекурсивная ссылка):
    public SelectedEntitysModel SelectedModel => _selectedEntitysModel;

    [SerializeField] private ICommand _actualCommand;

    private List<IMovmentGroup> _movmentRoyGroups = new();
    private int _movmentType = 0;


    private void OnEnable(){
        MapClickHendler.ClickOnMapRight += Move;
        ClickOnButtonsInUi.ActionClickOnMovmingType += SetMovmentType;
    }

    private void OnDisable(){
        MapClickHendler.ClickOnMapRight -= Move;
        ClickOnButtonsInUi.ActionClickOnMovmingType -= SetMovmentType;
       
    }

    public void SetMovmentType(int movmingTypeId){
        _movmentType = movmingTypeId;
    }



    private void MovmentRoyController(){        //вызывется каждый кадр

        if(this._movmentRoyGroups.Count == 0 || this._movmentRoyGroups==null){

        }
        else{
            IMovmentGroup group;
            for(int i=0;i<this._movmentRoyGroups.Count;i++){
                group = this._movmentRoyGroups[i];
                //group.Update();
                if(group.isCompleted()){
                    this._movmentRoyGroups.Remove(group);
                }
                else{
                    group.Update();
                }
            }
        }

    }

    private void Move(Vector3 target){

        //foreach(IEntity ent in this._selectedEntitysModel.SelectedEntitys){
            //ent.ClearCommandList();
            //ent.AddCommand(new MoveCommand(ent, target));
        //}
        List<IEntity> entitiesList = new();
        bool shiftIsActive = Input.GetKey(KeyCode.LeftShift);

        if(this._movmentType==0){

            if (shiftIsActive){
                
                this._movmentRoyGroups.Add(new MovmentRoy(this._selectedEntitysModel.SelectedEntitys, target));
                //Debug.Log("Shift");
            }
            else{

                if(this._selectedEntitysModel.SelectedEntitys.Count!=0){
                
                    if(this._movmentRoyGroups.Count !=0){//|| this._movmentRoyGroups!=null){
                        foreach(IEntity ent in this._selectedEntitysModel.SelectedEntitys){
                            foreach(MovmentRoy group in this._movmentRoyGroups){
                                if(group.EntityInGroup(ent)){
                                    entitiesList.Add(ent);
                                    group.RemoveEntityFromGroup(ent);
                                }
                                else{
                                    entitiesList.Add(ent);
                                }
                            }
                        }
                        this._movmentRoyGroups.Add(new MovmentRoy(entitiesList, target));
                    }
                    else{
                        this._movmentRoyGroups.Add(new MovmentRoy(this._selectedEntitysModel.SelectedEntitys, target));
                    }

            }
            }
        }
        else if(this._movmentType==1){

            if (shiftIsActive){
                this._movmentRoyGroups.Add(new MovmentFormation(this._selectedEntitysModel.SelectedEntitys, target));
            }
            else{

                if(this._movmentRoyGroups.Count !=0){//|| this._movmentRoyGroups!=null){
                        foreach(IEntity ent in this._selectedEntitysModel.SelectedEntitys){
                            foreach(MovmentFormation group in this._movmentRoyGroups){
                                if(group.EntityInGroup(ent)){
                                    entitiesList.Add(ent);
                                    group.RemoveEntityFromGroup(ent);
                                }
                                else{
                                    entitiesList.Add(ent);
                                }
                            }
                        }
                        this._movmentRoyGroups.Add(new MovmentFormation(entitiesList, target));
                    }
                    else{
                        this._movmentRoyGroups.Add(new MovmentFormation(this._selectedEntitysModel.SelectedEntitys, target));
                    }


            }

        }

    }




    public bool GiveCommand(ICommandFabrica commandFabrica)
    {
        Debug.Log($"EntitysController.GiveCommand вызван");
        
        if(_selectedEntitysModel == null)
        {
            Debug.LogError("_selectedEntitysModel равен null!");
            return false;
        }
        
        if(_selectedEntitysModel.SelectedEntitys == null)
        {
            Debug.LogError("SelectedEntitys равен null!");
            return false;
        }
        
        Debug.Log($"Выделенных юнитов: {_selectedEntitysModel.SelectedEntitys.Count}");
        
        if(_selectedEntitysModel.SelectedEntitys.Count == 0)
        {
            Debug.Log("❌ Нет выделенных юнитов!");
            return false;
        }
        
        bool result = false;

        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys)
        {
            Debug.Log($"Обрабатываем юнита: {ent.transform.name}");
            
            if(commandFabrica.CreateCommand(ref _actualCommand, ent))
            {
                Debug.Log($"✅ Команда создана: {_actualCommand}");
                result = true;
                ent.ClearCommandList();
                ent.AddCommand(_actualCommand);
            }
            else
            {
                Debug.LogError("❌ Не удалось создать команду!");
            }
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
