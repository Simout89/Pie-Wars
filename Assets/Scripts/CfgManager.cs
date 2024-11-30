using UnityEngine;

//будет парсить xml файлы конфига и закидывать настройки в переменные
public class CfgManager : MonoBehaviour
{
    //определяем все структуры(пока только для сахара)
    struct BasedEntityStruct  //стандартная структура для 1 здания/юнита
    {
        int HP;
        int AR;
        int EN;
        int SP;
        int VR;
        int AT;

        int AT_SPEED;   //скорость атаки
        int VALUE;  //кол-во ресурсов для найма
        int SCORE; //сколько очков стоит юнит
        int TIME; //время создания

        public void Create(int hp, int ar, int en, int sp, int vr, int at, int at_speed, int value, int score, int time)
        {
            this.HP = hp;
            this.AR = ar;
            this.EN = en;
            this.SP = sp;
            this.VR = vr;
            this.AT = at;
            this.AT_SPEED = at_speed;  //-1 если здание/юнит не может атаковать
            this.VALUE = value;
            this.SCORE = score;
            this.TIME = time;
        }
    }

    struct SUGAR_BUILD  //настройки для зданий сахара
    {
        BasedEntityStruct MainBuild;
        BasedEntityStruct Airfield;
        BasedEntityStruct Workshop;
        BasedEntityStruct Casern;
        BasedEntityStruct Mine;
        BasedEntityStruct Barracks;
        BasedEntityStruct Patrol;
        BasedEntityStruct Fort;
    }
    


    void Start()
    {
        
    }

    public void ParsSugarBuildsCfg() { }
    public void ParsSugarUnitsCfg() { }


}
