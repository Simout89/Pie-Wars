using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RebindUIButton : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button button;
    
    private InputAction _actionRef;
    private RebindUI _rebindUI;
    private int _bindingIndex;

    public void Initialize(InputAction actionRef, int bindingIndex, RebindUI rebindUI)
    {
        _actionRef = actionRef;
        _bindingIndex = bindingIndex;
        _rebindUI = rebindUI;

        text.text = _actionRef.bindings[bindingIndex].ToDisplayString();
    }
    
    private void Awake()
    {
        button.onClick.AddListener((() =>
        {
            _actionRef.Disable();

            // _actionRef.bindings[0]
        
            _actionRef.PerformInteractiveRebinding()
                .WithControlsExcluding("<Mouse>")
                .OnMatchWaitForAnother(0.1f)
                .WithTargetBinding(_bindingIndex)
                .OnComplete(_ =>
                {
                    _actionRef.Enable();
                    _rebindUI.ReloadButton();
                })
                .Start();
        }));
    }
}
