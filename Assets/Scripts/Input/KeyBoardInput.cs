using UnityEngine;

using System;

/// <summary>
/// события нажания на клавиатуру
/// </summary>


public class KeyBoardInput : MonoBehaviour
{
   public static event Action ActionPresentCtrlZ;


    public void Update(){

        //if (Input.GetKeyDown(KeyCode.LeftControl)){ //нажатие ctrl z
            //if (Input.GetKeyDown(KeyCode.Z)){

                if (Input.GetKeyUp(KeyCode.X)){
                    ActionPresentCtrlZ?.Invoke();
                    Debug.Log("Action active");
                }
               
            //}
        //}
    }

}
