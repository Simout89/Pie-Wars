using UnityEngine;

/// <summary>
/// система отвечающая за управление юнитами игроком. В автоматическом режиме юниты сами будут искать цель для атаки 
/// создает комманду на перемещение
/// создает комманду на атаку
/// содержит в себе модули, отвечающие за передвижение группы строем и роем
/// </summary>



public class UnitsController : MonoBehaviour
{
    [SerializeField] private SelectedEntitysModel _selectedUnitsModel;

    
    public void GiveCommand(Command command){       //отправит всем выделенным юнитам комманду

        
    
    }


}
