using UnityEngine;
using Zenject;

public class BuildSystemUIController : MonoBehaviour
{
    
    [Inject]private HexGrid hexGrid;

    

    [SerializeField]private GameObject buildSystemInterface;



    public void Show(bool ShowStatus){  //вызываетя, когда игрок переходит в режим строительства 
        this.hexGrid.gameObject.SetActive(ShowStatus);

        //this.buildSystemInterface.SetActive(ShowStatus);
        //Debug.Log(ShowStatus);
    }


    



    // Update is called once per frame
    void Update()
    {
        
    }
}
