using UnityEngine;
using Zenject;

public class BuildSystemUIController : MonoBehaviour
{
    
    [Inject]private HexGrid hexGrid;



    public void Show(bool ShowStatus){  //вызываетя, когда игрок переходит в режим строительства 
        hexGrid.gameObject.SetActive(ShowStatus);
        Debug.Log(ShowStatus);
    }


    



    // Update is called once per frame
    void Update()
    {
        
    }
}
