using UnityEngine;

public class BasedUnitClass : MonoBehaviour
{

    protected struct Characteristics {

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

        public int[] get() {
            return new int[] {this.HP, this.AR, this.EN, this.SP, this.VR, this.AT};
        }

        public void Damage(int dmg) {
            this.HP -= dmg;
        }
        public void Change_EN(int en) {
            this.EN -= en;
        }

    }



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
