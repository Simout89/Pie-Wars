using UnityEngine;

public class trasheynik:Unit
{
    //public trasheynik(){
        
    //}

    void Start(){
        Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[2];
    }

   
}
