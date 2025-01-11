using JetBrains.Annotations;
using UnityEngine;





public class EntityCfg{    //настройки для отдельной сющбности // settings for a separate entity
    private double HP;
    private double AR;
    private double EN;
    private double SP;
    private double VR;
    private double AT;
    private double ATS;
    private double AT_RANGE;
    private double COST_JR;
    private double COST_CK;
    private double SCORE;
    private double TIME_SPAWN;
    public EntityCfg(double[] data){
        HP = data[0];
        AR = data[1];
        EN = data[2];
        SP = data[3];
        VR = data[4];
        AT = data[5];
        ATS = data[6];
        AT_RANGE = data[7];
        COST_JR = data[8];
        COST_CK = data[9];
        SCORE = data[10];
        TIME_SPAWN = data[11];
    }

    public double[] getAll(){    
            return new double[] { this.HP, this.AR, this.EN, this.SP, this.VR, this.AT, this.ATS, this.AT_RANGE, this.COST_JR, this.COST_CK,this.SCORE, this.TIME_SPAWN };
    }
     public void Damage(double dmg)
        {           
            dmg = dmg * 0.1 * this.AR;
            this.HP -= dmg;
        }
        public void DamageSugar(double dmg)              
        {
            if (dmg <= this.AR)
            {
                this.AR -= dmg;
            }
            else
            {
                dmg -= this.AR;
                this.AR = 0;
                this.HP -= dmg;
            }
        }

        public void EnRegen()
        {           
            this.EN += Constants.EN_REGEN;
        }

        public void Change_EN(int en)
        {            
            this.EN -= en;
        }
}

public class BasedEntityClass : MonoBehaviour //БАЗОВЫЙ КЛАСС ДЛЯ ВСЕХ ЮНИТОВ И ЗДАНИЙ//BASIC CLASS FOR ALL UNITS AND BUILDINGS
{
    
    protected EntityCfg Characteristics;


    public BasedEntityClass(int enity_id){
        //this.Characteristics = Config.CfgData[enity_id_id];
        this.Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[enity_id];

    }
    public void Spawn(){}
    public void Destroy(){}
    public void Move(){}




}