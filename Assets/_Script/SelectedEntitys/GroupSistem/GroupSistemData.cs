using System.Collections.Generic;
using UnityEngine;

public class GroupSistemData : MonoBehaviour
{


    private const int _maxGroupsCount = Constants.UNITS_GROUPS_COUNT;
    private List<IEntity>[] _groups = new List<IEntity>[_maxGroupsCount];

    public void SetGroup(int index, List<IEntity> group){
        if(index<_maxGroupsCount && index>=0){
            _groups[index] = new(group);

        }else{
            Debug.Log("Error in GroupSistemData, func SetGroup: index>_maxGroupsCount or index<0");
        }
    }

    public List<IEntity>GetGroup(int index){

        return _groups[index];
    }
    


}
