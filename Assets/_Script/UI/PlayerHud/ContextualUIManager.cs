using UnityEngine;

public class ContextualUIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] huds;
    
    public void ChangePlayerHud(int id)
    {
        foreach (var hud in huds)
        {
            hud.SetActive(false);
        }
        huds[id].SetActive(true);
    }
}
