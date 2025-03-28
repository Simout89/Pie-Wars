using UnityEngine;
using Zenject;

public class BuildSystemController : MonoBehaviour
{

    [Inject]private HexGrid hexGrid;



    void Awake()
    {
        hexGrid.test();
    }
}
