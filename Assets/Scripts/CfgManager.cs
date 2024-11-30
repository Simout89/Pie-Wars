using UnityEngine;

//����� ������� xml ����� ������� � ���������� ��������� � ����������
public class CfgManager : MonoBehaviour
{
    //���������� ��� ���������(���� ������ ��� ������)
    struct BasedEntityStruct  //����������� ��������� ��� 1 ������/�����
    {
        int HP;
        int AR;
        int EN;
        int SP;
        int VR;
        int AT;

        int AT_SPEED;   //�������� �����
        int VALUE;  //���-�� �������� ��� �����
        int SCORE; //������� ����� ����� ����
        int TIME; //����� ��������

        public void Create(int hp, int ar, int en, int sp, int vr, int at, int at_speed, int value, int score, int time)
        {
            this.HP = hp;
            this.AR = ar;
            this.EN = en;
            this.SP = sp;
            this.VR = vr;
            this.AT = at;
            this.AT_SPEED = at_speed;  //-1 ���� ������/���� �� ����� ���������
            this.VALUE = value;
            this.SCORE = score;
            this.TIME = time;
        }
    }

    struct SUGAR_BUILD  //��������� ��� ������ ������
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
