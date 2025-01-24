using UnityEngine;

public sealed class UIService : MonoBehaviour{

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private new Camera camera;

    private RectTransform canvasTransform;

    private void Awake(){
        this.canvasTransform = this.canvas.GetComponent<RectTransform>();
    }

    public Vector2 GetUIPointByScreenPoint(Vector2 screenPoint){
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            this.canvasTransform,
            screenPoint,
            null,
            //this.camera,
            out var result
        );

        return result;
    }

    public Rect GetUIRectByScreenPoints(Vector2 startScreenPoint, Vector2 endScreenPoint){
        startScreenPoint = this.GetUIPointByScreenPoint(startScreenPoint);
        endScreenPoint = this.GetUIPointByScreenPoint(endScreenPoint);
            
        Vector2 center = (startScreenPoint + endScreenPoint) / 2;
        Vector2 vector = endScreenPoint - startScreenPoint;
        Vector2 size = new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        return new Rect(center, size);
    }
}