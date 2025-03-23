using System.Collections.Generic;
using UnityEngine;

public class GroupSistemController : MonoBehaviour
{
    [SerializeField] private GroupSistemData _groupSisteData;
    [SerializeField] private SelectedEntitysModel _selectedUnitsModel;
 

    private void OnEnable(){
        KeyBoardInput.ActionPresentCtrlNumber += NewGroup;
        KeyBoardInput.ActionPresentlNumber += SetGroup;
    }

    private void OnDisable(){
        KeyBoardInput.ActionPresentCtrlNumber -= NewGroup;
        KeyBoardInput.ActionPresentlNumber -= SetGroup;
    }
    
    public void NewGroup(int index){
        Debug.Log("New group");
        List<IEntity> group = _selectedUnitsModel.SelectedEntitys;
        _groupSisteData.SetGroup(index-1, group);
    }
    
    public void SetGroup(int index){
        Debug.Log("Set group");
        _selectedUnitsModel.SetOldSelectedUnitList(_groupSisteData.GetGroup(index-1));
    }

}
