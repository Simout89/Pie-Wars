using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyRebindUI : MonoBehaviour
{
    [SerializeField] private InputActionReference actionRef;
    [SerializeField] private Button rebindButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private CompositePart compositePart = CompositePart.Binding;

    private void Start()
    {
        rebindButton.onClick.AddListener(StartRebinding);
        UpdateButtonText();
    }

    private void StartRebinding()
    {
        actionRef.action.Disable();
        
        actionRef.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .OnMatchWaitForAnother(0.1f)
            .WithTargetBinding((int)compositePart)
            .OnComplete(_ =>
            {
                actionRef.action.Enable();
                UpdateButtonText();
            })
            .Start();
    }

    private void UpdateButtonText()
    {
        buttonText.text = "";

        foreach (var binding in actionRef.action.bindings)
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
