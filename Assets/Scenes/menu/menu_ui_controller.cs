using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_ui_controller : MonoBehaviour
{
    Animator ui_trigger;
    public int a = 9;


    void Start()
    {
        ui_trigger = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void Animator_trigger(int choise)
    {
        if (choise == 5)
        {
            Application.Quit();
        }
        else if(choise > 5) 
        {
            ui_trigger.SetTrigger("Trigger");
        }
        else
        {
            ui_trigger.SetTrigger("Trigger");
            ui_trigger.SetInteger("choose", choise);
        }
    }
}
