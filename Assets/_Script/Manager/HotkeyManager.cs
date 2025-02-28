using UnityEngine;
using UnityEngine.InputSystem;

public class HotkeyManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset controls;
    private InputAction saveAction;
    private InputAction nextAction;

    void Awake()
    {
        var gameplay = controls.FindActionMap("Player");
        saveAction = gameplay.FindAction("Save");
        nextAction = gameplay.FindAction("Next");

        nextAction.performed += _ =>
        {
            Debug.Log("Next");
        };
        saveAction.performed += _ => SaveGame();
        saveAction.Enable();
        nextAction.Enable();
    }

    void SaveGame()
    {
        Debug.Log("Игра сохранена!");
    }
}
