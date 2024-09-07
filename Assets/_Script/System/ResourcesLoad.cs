using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesLoad : MonoBehaviour
{
    private List<GameObject> _gameObjects = new();
    
    private void Awake()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        _gameObjects = Resources.LoadAll<GameObject>("EntityPrefabs").ToList();
    }

    public GameObject GetPrefabById(int id)
    {
        return _gameObjects[id];
    }
}
