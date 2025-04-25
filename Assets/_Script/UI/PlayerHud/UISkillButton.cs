using UnityEngine;
using UnityEngine.UI;

public class UISkillButton : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] public Button button;
    public void Init(Texture2D texture)
    {
        image.texture = texture;
    }
}
