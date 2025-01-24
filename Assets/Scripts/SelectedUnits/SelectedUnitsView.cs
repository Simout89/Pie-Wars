using UnityEngine.UI;
using UnityEngine;

public class SelectedUnitsView : MonoBehaviour
{
    
    private RectTransform _rectTransform;
    private Image _image;

    public void Awake(){
        this._rectTransform = this.GetComponent<RectTransform>();
        this._image = this.GetComponent<Image>();
    }


    public void SetPositions(Rect rect){
            this._rectTransform.sizeDelta = rect.size;
            this._rectTransform.anchoredPosition = new Vector2(rect.x, rect.y);
    }

    public void SetVisible(bool isVisible){
            this._image.enabled = isVisible;
    }


    
}
