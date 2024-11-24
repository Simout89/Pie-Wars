using UnityEngine;

public class BasedUnitClass : MonoBehaviour
{

    protected struct Characteristics {          //характеристики юнита

        private int HP;
        private int AR;
        private int EN;
        private int SP;
        private int VR;
        private int AT;

        public Characteristics(int hp, int ar, int en, int sp,int vr,int at)
        {
            this.HP = hp;
            this.AR = ar;
            this.EN = en;
            this.SP = sp;
            this.VR = vr;
            this.AT = at;
        }

        public int[] get() {            //возвращает текущие характеристики юнита
            return new int[] {this.HP, this.AR, this.EN, this.SP, this.VR, this.AT};
        }

        public void Damage(int dmg) {           //для всех, кроме фракции сахара /1 броня блокирует n% урона
            dmg = (int)(dmg * 0.1 * this.AR);
            this.HP -= dmg;
        }
        public void DamageSugar(int dmg)  //урон для сахара
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

        public void EnRegen() {         //реген энергии
            this.EN += Constants.EN_REGEN;
        }

        public void Change_EN(int en) { //расход энергии
            this.EN -= en;
        }
    }

    protected int FractionId;
    protected int Level;
    protected int Statis;



    public BasedUnitClass() {
    
        

    
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(Vector3 poz) { 
    
    
    }
    void Spawn(Vector3 poz) {
        transform.position = poz;
    
    }


}
