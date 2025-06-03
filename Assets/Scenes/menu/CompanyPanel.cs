using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CompanyPanel : MonoBehaviour
{
    [Inject] private SceneLoaderManager _sceneLoaderManager;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        _sceneLoaderManager.LoadScene(1);
    }
}
