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
    [SerializeField] private ICommandFabrica[] _commandsFabricsv = new ICommandFabrica[15];//содержит в себе объекты, которые создают комманды

    public void GiveCommand(ICommand command){       //очистит список комманд у выделенных юнитов и добавит им новую
        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys){
            ent.ClearCommandList();
            ent.AddCommand(command);
        }


    }

    public void AddCommand(ICommand command){//добавить юнитам комманду
        foreach(IEntity ent in _selectedEntitysModel.SelectedEntitys){
            ent.AddCommand(command);
        }
        
    }


}
