using System.Collections.Generic;
using UnityEngine;

public class HistorySelectedData : MonoBehaviour
{
  
    [SerializeField] private HistorySelectedStack HistoryData= new();

    public void NewRecordInHistory(List<IEntity> entitys_list){
        if(entitys_list.Count == 0){
            return;
        }else{
            HistoryData.Add(entitys_list);
        }
        
    }

    public List<IEntity> GetLastRecord(){
        
        return HistoryData.Get();
    }

}
