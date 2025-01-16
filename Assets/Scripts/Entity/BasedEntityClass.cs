using JetBrains.Annotations;
using UnityEngine;







public abstract class BasedEntityClass:MonoBehaviour //БАЗОВЫЙ КЛАСС ДЛЯ ВСЕХ ЮНИТОВ И ЗДАНИЙ//BASIC CLASS FOR ALL UNITS AND BUILDINGS
{
    protected EntityCfg Characteristics;
    public BasedEntityClass(int enity_id){
        //this.Characteristics = Config.CfgData[enity_id_id];
        //this.Characteristics = GameObject.Find("EnityConfig").GetComponent<Config>().CfgData[enity_id];

    }
    public abstract void Move(Vector3 cord);
    public abstract void Spawn(Vector3 cord);
    public abstract void Atack(BasedEntityClass target);
    public void Destroy(){

        
    }
}