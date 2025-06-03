using System.Collections.Generic;
using _Script.SelectedEntitys;
using UnityEngine;
using Zenject;

public class HistorySelectedController : MonoBehaviour
{

    [SerializeField] private HistorySelectedData _data;
    [Inject] private SelectedEntitysModel _selectedEntitysModel;
 

    private void OnEnable(){
        KeyBoardInput.ActionPresentCtrlZ += SetSelectedUnitsFromHistiry;
    }

    private void OnDisable(){
        KeyBoardInput.ActionPresentCtrlZ -= SetSelectedUnitsFromHistiry;
    }

    public void SetSelectedUnitsFromHistiry(){

        _selectedEntitysModel.SetOldSelectedUnitList(_data.GetLastRecord());
     
       
    }

    public void Awake(){
        
   }
}
