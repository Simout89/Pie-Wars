using UnityEngine;
using Zenject;






public class BuildSystemController : MonoBehaviour
{

    [Inject]private HexGrid hexGrid;

    private GameObject cube;


    private void OnEnable()
    {
        HexCell.MouseOnCell+=MouseOnCell;
    }

    private void OnDisable()
    {
       HexCell.MouseOnCell-=MouseOnCell;
    }


    private void MouseOnCell(HexCell cell){

        
            // Создаем луч из камеры в направлении курсора
            cube.transform.position = cell.transform.position;

    }

    void Awake()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    void Update()
    {
       
        
    }
}
