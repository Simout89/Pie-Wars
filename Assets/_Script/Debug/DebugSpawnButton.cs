using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class DebugSpawnButton: MonoBehaviour
{
    [SerializeField] private TMP_InputField _objectID;
    [SerializeField] private TMP_InputField _teamID;
    
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
        _cellsManager.SpawnEntity(_resourcesLoad.GetPrefabById(Convert.ToInt32(_objectID.text)), Convert.ToInt32(_teamID.text));
    }
}