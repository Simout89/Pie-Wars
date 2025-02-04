using UnityEngine;
using UnityEngine.UI;

public class UnActiveState : ISkillButtonState
{
    public void ShowEffect(Image image)
    {
        image.color = Color.gray;
    }
}
