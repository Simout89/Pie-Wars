using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class menu_ui_controller : MonoBehaviour
{
    public GameObject TargetObj;
    private Animator ui_trigger;
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
        else if (choise > 5)
        {
            ui_trigger.SetTrigger("Trigger");
        }
        else
        {
            if (choise == 0)
            {
                ui_trigger.SetTrigger("Trigger");
                ui_trigger.SetInteger("choose", choise);
            }
        }
    }
}
