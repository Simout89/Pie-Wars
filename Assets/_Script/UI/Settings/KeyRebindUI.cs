using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyRebindUI : MonoBehaviour
{
    private InputAction _actionRef;
    [SerializeField] private Button rebindButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private CompositePart compositePart = CompositePart.Binding;
    public void Initialize(InputAction actionRef)
    {
        _actionRef = actionRef;
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
            .WithTargetBinding((int)compositePart)
            .OnComplete(_ =>
            {
                _actionRef.Enable();
                UpdateButtonText();
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

    public enum CompositePart
    {
        Binding = 2,
        Modifier = 1,
    }
}
