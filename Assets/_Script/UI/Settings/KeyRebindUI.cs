using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyRebindUI : MonoBehaviour
{
    private InputAction _actionRef;
    [SerializeField] private Button rebindButton;
    [SerializeField] private TMP_Text buttonText;
    private RebindUI _rebindUI;
    private int _bindingIndex;
    public void Initialize(InputAction actionRef, int bindingIndex, RebindUI rebindUI)
    {
        _actionRef = actionRef;
        _bindingIndex = bindingIndex;
        _rebindUI = rebindUI;
        rebindButton.onClick.AddListener(StartRebinding);
        UpdateButtonText();
    }

    private void StartRebinding()
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
                UpdateButtonText();
                _rebindUI.ReloadButton();
            })
            .Start();
    }

    private void UpdateButtonText()
    {
        buttonText.text = $"{_actionRef.name} - ";

        for (int i = 0; i < _actionRef.bindings.Count; i++)
        {
            if(_actionRef.bindings[i].ToDisplayString() != "")
            {
                if(_bindingIndex == i)
                    buttonText.text += "<color=\"green\">" + _actionRef.bindings[i].ToDisplayString() + "<color=\"black\">+";
                else
                    buttonText.text += "<color=\"black\">" + _actionRef.bindings[i].ToDisplayString() + "+";
            }
        }

        buttonText.text = buttonText.text.Remove(buttonText.text.Length - 1);
    }
}
