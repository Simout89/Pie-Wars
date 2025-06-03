using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI metalText;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI crystalText;
    [SerializeField] private TextMeshProUGUI foodText;

    private void OnEnable()
    {
        ResourceManager.OnResourceChanged += UpdateResourceDisplay;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceChanged -= UpdateResourceDisplay;
    }

    private void Start()
    {
        UpdateAllResources();
    }

    private void UpdateResourceDisplay(ResourceType type, int amount)
    {
        switch(type)
        {
            case ResourceType.EmptyDough:
                metalText.text = $"Металл: {amount}";
                break;
            case ResourceType.SugarConcentrate:
                energyText.text = $"Энергия: {amount}";
                break;
            case ResourceType.WonderfulBeans:
                crystalText.text = $"Кристаллы: {amount}";
                break;
            case ResourceType.LivingDew:
                foodText.text = $"Еда: {amount}";
                break;
        }
    }

    private void UpdateAllResources()
    {
        if(ResourceManager.Instance != null)
        {
            UpdateResourceDisplay(ResourceType.EmptyDough, ResourceManager.Instance.GetResource(ResourceType.EmptyDough));
            UpdateResourceDisplay(ResourceType.SugarConcentrate, ResourceManager.Instance.GetResource(ResourceType.SugarConcentrate));
            UpdateResourceDisplay(ResourceType.WonderfulBeans, ResourceManager.Instance.GetResource(ResourceType.WonderfulBeans));
            UpdateResourceDisplay(ResourceType.LivingDew, ResourceManager.Instance.GetResource(ResourceType.LivingDew));
        }
    }
}