using System.Collections.Generic;
using UnityEngine;

public class HistorySelectedData : MonoBehaviour
{
  
    [SerializeField] private HistorySelectedStack HistoryData= new();

    public void NewRecordInHistory(List<Unit> units_list){
        if(units_list.Count == 0){
            return;
        }else{
            HistoryData.Add(units_list);
        }
        
    }

    public List<Unit> GetLastRecord(){
        
        return HistoryData.Get();
    }

}
