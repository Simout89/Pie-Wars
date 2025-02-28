using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindUI : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private KeyRebindUI keyPrefab;
    [SerializeField] private KeyRebindUI keyPrefabWithOneModifier;
    [SerializeField] private Transform viewPort;
    
    private List<GameObject> _rebindButtons = new List<GameObject>();

    private void Awake()
    {
        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        foreach (var inputActionMap in inputActionAsset.actionMaps)
        {
            foreach (var action in inputActionMap.actions)
            {
                List<int> bindingIndexes = new List<int>();
                for (int i = 0; i < action.bindings.Count; i++)
                {
                    Debug.Log(action.bindings[i]);
                    if (action.bindings[i].path.Split('/')[0] == "<Keyboard>")
                    {
                        bindingIndexes.Add(i);
                    }
                }
                KeyRebindUI keyUI = Instantiate(keyPrefab, viewPort);
                keyUI.Initialize(action, bindingIndexes.ToArray(), this);
                _rebindButtons.Add(keyUI.gameObject);
            }
        }
    }


    public void ReloadButton()
    {
        foreach (var rebindButton in _rebindButtons)
        {
            Destroy(rebindButton);
        }
        _rebindButtons.Clear();
        InstantiateButtons();
    }
}
