using UnityEngine;
using System.Collections;

public class ResourceNode : MonoBehaviour
{
    [Header("Resource Settings")]
    [SerializeField] private ResourceType resourceType = ResourceType.EmptyDough;
    [SerializeField] private int totalResources = 1000;
    [SerializeField] private int resourcesPerHarvest = 10;
    [SerializeField] private float harvestCooldown = 2f;
    
    private int currentResources;
    private bool canHarvest = true;
    private Renderer nodeRenderer;
    private Color originalColor;
    
    public ResourceType ResourceType => resourceType;
    public bool IsEmpty => currentResources <= 0;
    public bool CanHarvest => canHarvest && !IsEmpty;
    public float ResourcePercentage => (float)currentResources / totalResources;

    // НОВЫЙ ПУБЛИЧНЫЙ МЕТОД для установки типа ресурса
    public void SetResourceType(ResourceType newType)
    {
        resourceType = newType;
        SetNodeAppearance();
    }

    private void Start()
    {
        currentResources = totalResources;
        nodeRenderer = GetComponent<Renderer>();
        SetNodeAppearance();
        if(nodeRenderer != null)
        {
            originalColor = nodeRenderer.material.color;
        }
    }

    public int Harvest()
    {
        if(!CanHarvest) return 0;
        
        int harvestedAmount = Mathf.Min(resourcesPerHarvest, currentResources);
        currentResources -= harvestedAmount;
        
        canHarvest = false;
        Invoke(nameof(ResetHarvestCooldown), harvestCooldown);
        
        // Визуальные эффекты
        ShowHarvestEffect();
        UpdateNodeAppearance();
        
        Debug.Log($"Добыто {harvestedAmount} {resourceType}. Осталось: {currentResources}");
        
        // Добавляем ресурс в менеджер
        if(ResourceManager.Instance != null)
        {
            ResourceManager.Instance.AddResource(resourceType, harvestedAmount);
        }
        
        if(IsEmpty)
        {
            OnResourceDepleted();
        }
        
        return harvestedAmount;
    }

    private void ResetHarvestCooldown()
    {
        canHarvest = true;
    }

    private void ShowHarvestEffect()
    {
        // Эффект мигания
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        if(nodeRenderer != null)
        {
            Color blinkColor = Color.white;
            nodeRenderer.material.color = blinkColor;
            yield return new WaitForSeconds(0.1f);
            if(nodeRenderer != null)
            {
                nodeRenderer.material.color = originalColor;
            }
        }
    }

    private void UpdateNodeAppearance()
    {
        if(nodeRenderer != null)
        {
            // Делаем узел темнее по мере истощения
            float brightness = Mathf.Lerp(0.3f, 1f, ResourcePercentage);
            Color newColor = originalColor * brightness;
            nodeRenderer.material.color = newColor;
        }
    }

    private void OnResourceDepleted()
    {
        Debug.Log($"Ресурс {resourceType} истощен!");
        if(nodeRenderer != null)
        {
            nodeRenderer.material.color = Color.gray;
        }
        
        StartCoroutine(DepletionEffect());
    }

    private IEnumerator DepletionEffect()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void SetNodeAppearance()
    {
        if(nodeRenderer == null) 
        {
            nodeRenderer = GetComponent<Renderer>();
        }
        
        if(nodeRenderer != null)
        {
            Color nodeColor = resourceType switch
            {
                ResourceType.EmptyDough => new Color(0.7f, 0.7f, 0.7f),   // Серый
                ResourceType.SugarConcentrate => new Color(1f, 1f, 0f),       // Желтый
                ResourceType.WonderfulBeans => new Color(0.3f, 0.7f, 1f),  // Синий
                ResourceType.LivingDew => new Color(0.2f, 0.8f, 0.2f),   // Зеленый
                _ => Color.white
            };
            nodeRenderer.material.color = nodeColor;
            originalColor = nodeColor;
        }
        
        gameObject.name = $"{resourceType}_Node";
    }

    // Показать информацию при наведении мыши
    private void OnMouseEnter()
    {
        Debug.Log($"{resourceType}: {currentResources}/{totalResources} ({ResourcePercentage:P0})");
    }
}