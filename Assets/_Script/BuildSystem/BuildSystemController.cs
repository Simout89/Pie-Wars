using UnityEngine;
using UnityEngine.UIElements;
using Zenject;






public class BuildSystemController : MonoBehaviour
{

    [Inject]private HexGrid hexGrid;
    [Inject]private ObjectsPoolData objPoolData;

    [Inject] private DiContainer _container;



    //[SerializeField] private BuildSystemUIView UIView;
    [SerializeField] BuildSystemUIController UIController;

    

    [SerializeField] private bool isActive = false;



    private Build actualBuild; //здание, которое игрок планирует построить

    [SerializeField] private Build buildPrefab; //в дальнейшем передавать его при вызове функции строительства


    private void OnEnable()
    {
        HexCell.MouseOnCell+=MouseOnCell;
    }

    private void OnDisable()
    {
       HexCell.MouseOnCell-=MouseOnCell;
    }


    private void SetPreviewAppearance(Build build)
    {
        
        foreach (var renderer in build.GetComponentsInChildren<Renderer>())
        {
            foreach (var mat in renderer.materials)
            {
                Color color = mat.color;
                color.a = 0.4f;
                mat.color = color;
                mat.SetFloat("_Mode", 2); // Transparent mode
            }
        }

        Collider col = build.GetComponent<Collider>();
        if (col) col.enabled = false;
    }



    private void MouseOnCell(HexCell cell){

        if (isActive && actualBuild == null) {

            actualBuild = GameObject.Instantiate(buildPrefab, cell.transform.position, Quaternion.identity);
            _container.Inject(actualBuild);
            //this.SetPreviewAppearance(actualBuild);
            actualBuild.enabled = false;

        }
        if (isActive && actualBuild != null)
        {
            
            actualBuild.enabled = false;
            Vector3 pos = cell.transform.position;
            pos.y += 11f; //
            actualBuild.transform.position = pos;

           


        }
        
            
        

    }

    public void EnableBuilding(){ //вызываетя, когда игрок переходит в режим строительства 
        this.isActive = !this.isActive;
        this.UIController.Show(this.isActive);
        
    }

    void Awake()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0) && isActive && actualBuild != null) // Левая кнопка мыши
        {
            objPoolData.AddBuild(actualBuild);
            actualBuild.enabled = true;
            actualBuild = null;
            isActive = false;
            this.UIController.Show(this.isActive);
        }


    }
}
