using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Threading;
public class main_menu : MonoBehaviour
{
    [SerializeField] protected GameObject TargetObj;
    private menu_ui_controller _actionTarget;
    void Start()
    {
        _actionTarget = TargetObj.GetComponent<menu_ui_controller>();
    }
    void Update()
    {
    }
    public void from_menu_to_other(int choise)
    {
        _actionTarget.animation_controller(choise);
    }
}