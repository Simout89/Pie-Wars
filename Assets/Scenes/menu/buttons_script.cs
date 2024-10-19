using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons_script : MonoBehaviour
{
    public GameObject TargetObj;
    private menu_ui_controller _actionTarget;
    
    private void Start()
    {
        _actionTarget = TargetObj.GetComponent<menu_ui_controller>();
    }
    public void trigger(int for_example)
    {
        _actionTarget.Animator_trigger(for_example);
    }
    public void settings_ui_buttons()
    {
        GameObject key_board = GameObject.Find("keyboard");
        key_board.SetActive(false);
        GameObject game = GameObject.Find("game");
        key_board.SetActive(false);
        GameObject audio = GameObject.Find("audio");
        key_board.SetActive(false);
        GameObject video = GameObject.Find("video");
        key_board.SetActive(false);
    }
    public void settings_ui_switchers()
    {

    }

    public void info_ui_buttons()
    {

    }

    void info_ui_switchers()
    {

    }
}