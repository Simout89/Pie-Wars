using System.Collections.Generic;
using UnityEngine;

public class GroupSistemData : MonoBehaviour
{


    private const int _maxGroupsCount = Constants.UNITS_GROUPS_COUNT;
    private List<Unit>[] _groups = new List<Unit>[_maxGroupsCount];

    public void SetGroup(int index, List<Unit> group){
        if(index<_maxGroupsCount && index>=0){
            _groups[index] = new(group);

        }else{
            Debug.Log("Error in GroupSistemData, func SetGroup: index>_maxGroupsCount or index<0");
        }
    }

    public List<Unit>GetGroup(int index){

        return _groups[index];
    }
    


}
