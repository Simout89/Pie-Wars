using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    
    [SerializeField] private ResourceData playerResources = new ResourceData();
    
    public static event Action<ResourceType, int> OnResourceChanged;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddResource(ResourceType type, int amount)
    {
        playerResources.AddResource(type, amount);
        OnResourceChanged?.Invoke(type, playerResources.GetResource(type));
    }

    public bool SpendResource(ResourceType type, int amount)
    {
        bool success = playerResources.SpendResource(type, amount);
        if(success)
        {
            OnResourceChanged?.Invoke(type, playerResources.GetResource(type));
        }
        return success;
    }

    public int GetResource(ResourceType type)
    {
        return playerResources.GetResource(type);
    }
}