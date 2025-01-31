using UnityEngine;

using System;

/// <summary>
/// события нажания на клавиатуру
/// В ДАННЫЙ МОМЕНТ ВМЕСТО CTRL ИСПОЛЬЗУЕСТЯ C
/// </summary>


public class KeyBoardInput : MonoBehaviour
{

    private bool ctrIsActive;//зажат ли
    public static event Action ActionPresentCtrlZ;//нажате ctrl+z
   
    public static event Action<int> ActionPresentCtrlNumber;//Нажатие ctrl+число, для бинда групп
    public static event Action<int> ActionPresentlNumber;
   

    public void Update(){

        if (Input.GetKey(KeyCode.C)){ //зажатие ctrl
            this.ctrIsActive = true;
        }else if(Input.GetKeyUp(KeyCode.C)){//отпустили ctrl
            this.ctrIsActive = false; 
        }
        if (ctrIsActive && Input.GetKeyUp(KeyCode.Z)){
            ActionPresentCtrlZ?.Invoke();
        }

        if (ctrIsActive==false && Input.GetKeyUp(KeyCode.Alpha1)){
            ActionPresentlNumber?.Invoke(1);
        }
        if (ctrIsActive==false && Input.GetKeyUp(KeyCode.Alpha2)){
            ActionPresentlNumber?.Invoke(2);
        }
        if (ctrIsActive==false && Input.GetKeyUp(KeyCode.Alpha3)){
            ActionPresentlNumber?.Invoke(3);
        }
        if (ctrIsActive==false && Input.GetKeyUp(KeyCode.Alpha4)){
            ActionPresentlNumber?.Invoke(4);
        }
        if (ctrIsActive==false && Input.GetKeyUp(KeyCode.Alpha5)){
            ActionPresentlNumber?.Invoke(6);
        }
        if (ctrIsActive==false && Input.GetKeyUp(KeyCode.Alpha6)){
            ActionPresentlNumber?.Invoke(6);
        }


        if (ctrIsActive && Input.GetKeyUp(KeyCode.Alpha1)){
            ActionPresentCtrlNumber?.Invoke(1);
        }
        if (ctrIsActive && Input.GetKeyUp(KeyCode.Alpha2)){
            ActionPresentCtrlNumber?.Invoke(2);
        }
         if (ctrIsActive && Input.GetKeyUp(KeyCode.Alpha3)){
            ActionPresentCtrlNumber?.Invoke(3);
        }
         if (ctrIsActive && Input.GetKeyUp(KeyCode.Alpha4)){
            ActionPresentCtrlNumber?.Invoke(4);
        }
         if (ctrIsActive && Input.GetKeyUp(KeyCode.Alpha5)){
            ActionPresentCtrlNumber?.Invoke(5);
        }
         if (ctrIsActive && Input.GetKeyUp(KeyCode.Alpha6)){
            ActionPresentCtrlNumber?.Invoke(6);
        }    
               
    }
        
   

}
