using System.Collections.Generic;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    
    private List<Entity> _entities = new List<Entity>();
    
    public void SpawnEntity(GameObject entity)
    {
        GameObject emergedEntity = Instantiate(entity);
         _entities.Add(emergedEntity.GetComponent<Entity>());
    }
    
}