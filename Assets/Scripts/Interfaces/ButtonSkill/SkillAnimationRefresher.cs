using UnityEngine;
using UnityEngine.UI;


public class SkillAnimationRefresher : MonoBehaviour
{
    public Image image;
    public float map_button_width;
    public float map_button_height;

    private void Start () {
        GameObject newObject = new GameObject("Filler");
        RectTransform rectTransform = newObject.AddComponent<RectTransform>();
       // rectTransform.sizeDelta = new Vector2(width, height);
        
    }
};
