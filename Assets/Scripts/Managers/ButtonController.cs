using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMapModeSpawnSugar002(){
        this.GetComponent<MapClickHendler>().SetMapMode(Constants.MODE_MAP_SPAWN);
        this.GetComponent<MapClickHendler>().SetEntityId(2);

    }
}
