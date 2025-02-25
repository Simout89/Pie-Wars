using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindUI : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private KeyRebindUI keyPrefab;
    [SerializeField] private Transform viewPort;

    private void Awake()
    {
        foreach (var inputActionMap in inputActionAsset.actionMaps)
        {
            foreach (var action in inputActionMap.actions)
            {
                if(action.bindings[0].isComposite)
                {
                    KeyRebindUI keyUI = Instantiate(keyPrefab, viewPort);
                    keyUI.Initialize(action);
                }
            }
        }
    }
}
