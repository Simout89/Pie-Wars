using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadPreBuild : MonoBehaviour
{
    public void Load()
    {
        Debug.Log("Load preBuild");
        SceneManager.LoadScene("Scenes/Test Scense/preBuild");
    }

}
