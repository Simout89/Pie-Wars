using UnityEngine;

using System;


//функции для обрадотки нажатий на кнопки

public class ClickOnButtonsInUi : MonoBehaviour
{

    
   
    public static event Action<int> ActionClickOnMovmingType;//нажате на кнопку, для выбора типа перемещения


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void CliclOnMovmingRoy(){
        ActionClickOnMovmingType?.Invoke(0);
    }
    public void CliclOnMovmingFromation(){
        ActionClickOnMovmingType?.Invoke(1);
    }


}
