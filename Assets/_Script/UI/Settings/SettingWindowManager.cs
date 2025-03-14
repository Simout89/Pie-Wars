using UnityEngine;
using UnityEngine.UI;

public class SettingWindowManager : MonoBehaviour
{
    [SerializeField] private UIElementToggle[] elementToggles;
    
    private void Start()
    {
        for (int i = 0; i < elementToggles.Length; i++)
        {
            int index = i;
            elementToggles[i].button.onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int index)
    {
        foreach (var VARIABLE in elementToggles)
        {
            VARIABLE.UIElement.SetActive(false);
        }
        elementToggles[index].UIElement.SetActive(true);
    }
}

[System.Serializable]
public class UIElementToggle
{
    [SerializeField] public Button button;
    [SerializeField] public GameObject UIElement;
}