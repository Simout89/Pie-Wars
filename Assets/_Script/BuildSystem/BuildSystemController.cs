using UnityEngine;
using UnityEngine.UIElements;
using Zenject;






public class BuildSystemController : MonoBehaviour
{

    [Inject]private HexGrid hexGrid;

    //[SerializeField] private BuildSystemUIView UIView;
    [SerializeField] BuildSystemUIController UIController;

    private Build actualBuild; //здание, которое игрок планирует построить

    [SerializeField] private bool isActive = false;
 



    private void OnEnable()
    {
        HexCell.MouseOnCell+=MouseOnCell;
    }

    private void OnDisable()
    {
       HexCell.MouseOnCell-=MouseOnCell;
    }


    private void MouseOnCell(HexCell cell){

        
            
            //cube.transform.position = cell.transform.position;

    }

    public void EnableBuilding(){ //вызываетя, когда игрок переходит в режим строительства 
        this.isActive = !this.isActive;
        this.UIController.Show(this.isActive);
        
    }

    void Awake()
    {
        //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    void Update()
    {
       
        
    }
}
