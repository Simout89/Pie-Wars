using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyRebindUI : MonoBehaviour
{
    [SerializeField] private RebindUIButton rebindButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Transform buttonContainer;
    public void Initialize(InputAction actionRef, int[] bindingIndex, RebindUI rebindUI)
    {
        buttonText.text = actionRef.name;

        foreach (var binding in bindingIndex)
        {
            var rebindButtonInst = Instantiate(rebindButton, buttonContainer);
            rebindButtonInst.Initialize(actionRef, binding, rebindUI); 
        }
    }
}
