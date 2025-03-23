using UnityEngine;


/// <summary>
/// проверяет находиться ли объект в прямоугольной области
/// Объект должен иметь компонет Transform
/// </summary>

public class ObjectInRect : MonoBehaviour
{
   [SerializeField] private Camera _mainCamera;
    public bool PointInRect(Vector3 point, Vector2 startPoint, Vector2 endPoint){

        //bool result = false;
        // трансформируем позицию объекта из мирового пространства, в пространство экрана
		Vector2 pointInScreen = new Vector2(_mainCamera.WorldToScreenPoint(point).x, _mainCamera.WorldToScreenPoint(point).y);

        float minX = Mathf.Min(startPoint.x, endPoint.x);
        float maxX = Mathf.Max(startPoint.x, endPoint.x);;
        float minY = Mathf.Min(startPoint.y, endPoint.y);;
        float maxY = Mathf.Max(startPoint.y, endPoint.y);;



        return pointInScreen.x >= minX && pointInScreen.x <= maxX && pointInScreen.y >= minY && pointInScreen.y <= maxY;
    }

}
