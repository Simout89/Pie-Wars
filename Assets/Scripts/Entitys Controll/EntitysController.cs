using UnityEngine;

/// <summary>
/// система отвечающая за управление юнитами игроком. В автоматическом режиме юниты сами будут искать цель для атаки 
/// создает комманду на перемещение
/// создает комманду на атаку
/// содержит в себе модули, отвечающие за передвижение группы строем и роем
/// </summary>



public class EntitysControllModel : MonoBehaviour
{
    [SerializeField] private SelectedEntitysModel _selectedEntitysModel;
    [SerializeField] private ICommandFabrica[] _commandsFabricsv = new ICommandFabrica[15];//содержит в себе объекты, которые создают комманды




    void CreateCommand(int buttonId){ //создаст запрошенную комманд

    }
    public void GiveCommand(int buttonId){       //очистит список комманд у выделенных юнитов и добавит им новую
    
    }

    public void AddCommand(int buttonId){        //добавит к уже имеющимся командам новую

    }


}
