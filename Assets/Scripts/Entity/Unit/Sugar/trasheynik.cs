using UnityEngine;

public class trasheynik:Unit
{
    //public trasheynik(){
        
    //}

    void Start(){
        MoveCord = transform.position;
        Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[2];
    }

    public override void AtackUnit(ref Unit target){
        TypesOfAtack.AtackShogunUnit(ref target);
    }

    public override void AtackBuild(ref Build target){
        AtackBuild(ref target);
    }
}
