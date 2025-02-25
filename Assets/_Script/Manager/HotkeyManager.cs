using UnityEngine;
using UnityEngine.InputSystem;

public class HotkeyManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset controls;
    private InputAction saveAction;

    void Awake()
    {
        var gameplay = controls.FindActionMap("Player");
        saveAction = gameplay.FindAction("Save");

        saveAction.performed += _ => SaveGame();
        saveAction.Enable();
    }

    void SaveGame()
    {
        Debug.Log("Игра сохранена!");
    }
}
