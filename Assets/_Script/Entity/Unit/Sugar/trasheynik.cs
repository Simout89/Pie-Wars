using UnityEngine;

public class trasheynik:Unit
{
    //public trasheynik(){

    //}

    public override void InitUnit()
    {
        Characteristics = new EntityCfg();
        AttackInRadius attackInRadiusCommand= new AttackInRadius(this,50,1);
        this._staticCommandList.Add(attackInRadiusCommand);


    }






    protected override void Start(){
        base.Start();
        this.InitUnit();
        //Debug.Log("12321");
        //Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[2];
    }

   
}
