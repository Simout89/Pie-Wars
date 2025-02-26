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

        foreach (var binding in _actionRef.bindings)
        {
            if(binding.ToDisplayString() != "")
                buttonText.text += binding.ToDisplayString() + "+";
        }

        buttonText.text = buttonText.text.Remove(buttonText.text.Length - 1);
    }
}
