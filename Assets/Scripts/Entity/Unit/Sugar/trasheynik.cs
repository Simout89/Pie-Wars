using UnityEngine;

public class trasheynik:Unit
{
    //public trasheynik(){
        
    //}

    void Start(){
        MoveCord = transform.position;
        Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[2];
    }

    public override void Atack(Unit target){

    }
}
