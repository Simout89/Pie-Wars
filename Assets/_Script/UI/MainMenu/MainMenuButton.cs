using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        
    }
}
