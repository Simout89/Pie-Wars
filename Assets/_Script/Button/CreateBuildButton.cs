using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class CreateBuildButton : MonoBehaviour
{
    [Inject] private CellsManager _cellsManager;
    [Inject] private ResourcesLoad _resourcesLoad;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleOnClick);
    }

    private void HandleOnClick()
    {
        _cellsManager.SpawnEntity(_resourcesLoad.GetPrefabById(0), 0);
    }
}
