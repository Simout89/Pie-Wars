using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Threading;

public class menu_ui_controller : MonoBehaviour
{
    static int which_elements_must_hide = 0;
    public GameObject TargetObj;
    private Animator ui_trigger;

    protected GameObject PC_game;
    protected GameObject LAN_game;
    protected GameObject company;
    protected GameObject settings;
    protected GameObject info;
    protected GameObject main;

    protected GameObject key_board;
    protected GameObject game_p;
    protected GameObject audio_p;
    protected GameObject video_p;

    protected GameObject switch_camera;
    protected GameObject switch_units;
    protected GameObject switch_buildings;
    protected GameObject switch_game;

    protected GameObject switch_info_ice_cream;
    protected GameObject switch_info_sugar;
    protected GameObject switch_info_bread;
    protected GameObject switch_info_chocolate;

    void Start()
    {
        ui_trigger = GetComponent<Animator>();

        PC_game = GameObject.Find("panel_for_game_properties");
        LAN_game = GameObject.Find("panel_for_LAN_game");
        company = GameObject.Find("panel_for_company");
        settings = GameObject.Find("panel_for_settings");
        info = GameObject.Find("panel_for_info");
        main = GameObject.Find("fade_in");
        
        key_board = GameObject.Find("panel_for_settings/panel_view/Panel_key_board");
        game_p = GameObject.Find("panel_for_settings/panel_view/Panel_game");
        audio_p = GameObject.Find("panel_for_settings/panel_view/Panel_audio");
        video_p = GameObject.Find("panel_for_settings/panel_view/Panel_video");


        switch_camera = GameObject.Find("panel_for_settings/panel_view/Panel_key_board/camera_switcher");
        switch_units = GameObject.Find("panel_for_settings/panel_view/Panel_key_board/units_switcher");
        switch_buildings = GameObject.Find("panel_for_settings/panel_view/Panel_key_board/builds_switcher");
        switch_game = GameObject.Find("panel_for_settings/panel_view/Panel_key_board/game_switcher");

        switch_info_ice_cream = GameObject.Find("panel_for_info/window_info/ice_cream");
        switch_info_sugar = GameObject.Find("panel_for_info/window_info/sugar");
        switch_info_bread = GameObject.Find("panel_for_info/window_info/bread");
        switch_info_chocolate = GameObject.Find("panel_for_info/window_info/chocolate");
        
        PC_game.SetActive(false);
        LAN_game.SetActive(false);
        company.SetActive(false);
        settings.SetActive(false);
        info.SetActive(false);
    }
    void Update()
    {
    }
    public void animation_controller(int choise)
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
            ui_trigger.SetTrigger("Trigger");
            ui_trigger.SetInteger("choose", choise);
            while(this.ui_trigger.GetCurrentAnimatorStateInfo(0).IsName("company")==false)
            {
                Debug.Log(which_elements_must_hide);
            }
            which_elements_must_hide = choise;
            main_hide_ui_function();
        }
    }
    public void main_hide_ui_function()
    {
        Debug.Log(which_elements_must_hide);
        switch (which_elements_must_hide)
        {
            case 0:
                main.SetActive(false);//change menu theme to company
                company.SetActive(true);
                break;
            case 1:
                main.SetActive(false);//change menu theme to game with PC
                PC_game.SetActive(true);
                break;
            case 2:
                main.SetActive(false);//change menu theme to game with other gamers
                LAN_game.SetActive(true);
                break;
            case 3:
                main.SetActive(false);//change menu theme to settings
                settings.SetActive(true);
                break;
            case 4:
                main.SetActive(false);//change menu theme to iformation about units and buildings
                info.SetActive(true);
                break;
            case 5:
                main.SetActive(true);//change other theme to main menu
                company.SetActive(false);
                PC_game.SetActive(false);
                LAN_game.SetActive(false);
                settings.SetActive(false);
                info.SetActive(false);
                break;
        }
    }
    public void submenues_hide_ui_function()
    {
        switch (which_elements_must_hide)
        {
            // next are the transitions for the settings
            case 6:
                key_board.SetActive(true);
                game_p.SetActive(false);
                audio_p.SetActive(false);
                video_p.SetActive(false);
                break;
            case 7:
                key_board.SetActive(false);
                game_p.SetActive(true);
                audio_p.SetActive(false);
                video_p.SetActive(false);
                break;
            case 8:
                key_board.SetActive(false);
                game_p.SetActive(false);
                audio_p.SetActive(true);
                video_p.SetActive(false);
                break;
            case 9:
                key_board.SetActive(false);
                game_p.SetActive(false);
                audio_p.SetActive(false);
                video_p.SetActive(true);
                break;
            // next are the transitions for the keyboard settings
            case 10:
                switch_camera.SetActive(true);
                switch_units.SetActive(false);
                switch_buildings.SetActive(false);
                switch_game.SetActive(false);
                break;
            case 11:
                switch_camera.SetActive(false);
                switch_units.SetActive(true);
                switch_buildings.SetActive(false);
                switch_game.SetActive(false);
                break;
            case 12:
                switch_camera.SetActive(false);
                switch_units.SetActive(false);
                switch_buildings.SetActive(true);
                switch_game.SetActive(false);
                break;
            case 13:
                switch_camera.SetActive(false);
                switch_units.SetActive(false);
                switch_buildings.SetActive(false);
                switch_game.SetActive(true);
                break;
            // next are the transitions for the information sheets
            case 14:
                switch_info_ice_cream.SetActive(true);
                switch_info_sugar.SetActive(false);
                switch_info_bread.SetActive(false);
                switch_info_chocolate.SetActive(false);
                break;
            case 15:
                switch_info_ice_cream.SetActive(false);
                switch_info_sugar.SetActive(true);
                switch_info_bread.SetActive(false);
                switch_info_chocolate.SetActive(false);
                break;
            case 16:
                switch_info_ice_cream.SetActive(false);
                switch_info_sugar.SetActive(false);
                switch_info_bread.SetActive(true);
                switch_info_chocolate.SetActive(false);
                break;
            case 17:
                switch_info_ice_cream.SetActive(false);
                switch_info_sugar.SetActive(false);
                switch_info_bread.SetActive(false);
                switch_info_chocolate.SetActive(true);
                break;
            case 18:

                break;
            case 19:

                break;
            case 20:

                break;
            case 21:

                break;
        }
    }
}