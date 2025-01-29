using System.Collections.Generic;
using UnityEngine;

public class HistorySelectedController : MonoBehaviour
{

    [SerializeField] private HistorySelectedData _data;
    [SerializeField] private SelectedUnitsModel _selectedUnitsModel;
 

    private void OnEnable(){
        KeyBoardInput.ActionPresentCtrlZ += SetSelectedUnitsFromHistiry;
    }

    private void OnDisable(){
        KeyBoardInput.ActionPresentCtrlZ -= SetSelectedUnitsFromHistiry;
    }

    public void SetSelectedUnitsFromHistiry(){

        Debug.Log("click");
        _selectedUnitsModel.SetOldSelectedUnitList(_data.GetLastRecord());
     
       
    }

    public void Awake(){
        
   }
}
