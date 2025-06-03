using UnityEngine;

public class ResourceNodeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject resourceNodePrefab;
    [SerializeField] private int nodesPerType = 5;
    [SerializeField] private float spawnRadius = 50f;

    private void Start()
    {
        SpawnResourceNodes();
    }

    private void SpawnResourceNodes()
    {
        foreach(ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            for(int i = 0; i < nodesPerType; i++)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                spawnPosition.y = 0; // На уровне земли

                GameObject nodeObj = Instantiate(resourceNodePrefab, spawnPosition, Quaternion.identity);
                ResourceNode node = nodeObj.GetComponent<ResourceNode>();
                
                // Установка типа ресурса через рефлекцию или сериализацию
                var field = typeof(ResourceNode).GetField("resourceType", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                field?.SetValue(node, resourceType);
                
                nodeObj.name = $"{resourceType}_Node_{i}";
            }
        }
    }
}