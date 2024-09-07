using System.Collections.Generic;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    private readonly Vector3 startpos = new(-111.838058f, 23.6800003f, -120.072922f);

    private List<Entity> _entities = new();
    
    public void SpawnEntity(GameObject entity)
    {
        GameObject emergedEntity = Instantiate(entity, new Vector3(startpos.x + Random.Range(0,5), startpos.y, startpos.z + Random.Range(0,5)), Quaternion.identity);
        _entities.Add(emergedEntity.GetComponent<Entity>());
        ////
        emergedEntity.GetComponent<Entity>().PlaySoundOnSpawn();
    }
    
}