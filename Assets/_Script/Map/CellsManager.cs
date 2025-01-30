using System.Collections.Generic;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    private readonly Vector3 startpos = new(-111.838058f, 23.6800003f, -120.072922f);

    private List<Entity> _entities = new();
    
    public void SpawnEntity(GameObject entity, int teamId)
    {
        GameObject emergedGameObject = Instantiate(entity, new Vector3(startpos.x + Random.Range(0,5), startpos.y, startpos.z + Random.Range(0,5)), Quaternion.identity);
        Entity emergedEntity = emergedGameObject.GetComponent<Entity>();
        emergedEntity.TeamId = teamId;
        _entities.Add(emergedEntity);
        ////
        emergedGameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB((float)teamId/10, 1, 1);
        ////
        emergedEntity.PlaySoundOnSpawn();
        
    }
    
}