using System;
using System.Collections.Generic;
using UnityEngine;

public class HistorySelectedData : MonoBehaviour
{
    public event Action<IEntity> OnSelected;

  
    [SerializeField] private HistorySelectedStack HistoryData= new();

    public void NewRecordInHistory(List<IEntity> entitys_list){
        if(entitys_list.Count == 0){
            return;
        }else{
            
            HistoryData.Add(entitys_list);
            
            OnSelected?.Invoke(entitys_list[0]);
        }
        
    }

    public List<IEntity> GetLastRecord(){
        
        return HistoryData.Get();
    }

}
