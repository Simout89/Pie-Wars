//��� ���������


using UnityEditor;

static class Constants
{
    //main consts
    public const string CFG_PATH = "D:\\cfg_v2.dat";
    public const int COUNT_ENTITY = 17;//кол-во сущностей 
    //main consts
    public const int FRACTION_NEUTRAL = 0;//����������� �������(�����, ������� � ��������)
    public const int FRACTION_PASTRY=1;//�����              ��������� �������
    public const int FRACTION_ICE = 2;//���������
    public const int FRACTION_CHOCOLATE = 3;//�������       
    public const int FRACTION_SUGAR = 4;//�����
    //��������� ��������� ������
    public const int BUILD_WORK_PASSIVE = 1;//������ �������� �������
    public const int BUILD_STOP_PASSIVE = 2;//������ ����������� �������
    public const int BUILD_WORK_ACTIVELY = 3;//������ ���-�� ���������
    public const int BUILD_SHORTAGE = 4;//�������� ��������
    //��������� �� ������ � �������
   
    

    //id всех юнитов и зданий//id of all units and buildings
    //sugar
    public const int SUGAR_UNIT_PEKHOTINEC = 0;
    public const int SUGAR_UNIT_GRENADER = 1;



    //режим карты//mode map
    public const int MODE_MAP_DEFAULT = 0; //СТАНДАРТНОЕ СОСТОЯНИЕ КАРТЫ
    public const int MODE_MAP_WAIT_TARGET = 1; //ожидает точки, куда пойдут юнит(ы)
    
   
    //public const int MODE_MAP_WAIT_TARGET_ATACK = 2;//ОЖИДАЕТ ЦЕЛИ ДЛЯ АТАКИ
    public const int MODE_MAP_WAIT_FLAG_SOLIDER = 2;//ОЖИДАЕТ КЛИКА ПО ТОЧКЕ, КУДА БУДУТ ИДТИ ЮНИТЫ-СОЛДАТЫ ПОСЛЕ СПАВНА
    public const int MODE_MAP_WAIT_FLAG_WORKER = 3;//ОЖИДАЕТ КЛИКА ПО ТОЧКЕ, КУДА БУДУТ ИДТИ ЮНИТЫ-РАБОЧИЕ ПОСЛЕ СПАВНА
    public const int MODE_MAP_SPAWN = 4; //ожидает клика по месту для строительства/спавнв юнита
    


    //��������� ��� ������
    public const int EN_REGEN = 1; //����� ������� � 1 �������

    //������ ������ �����������
    public const float BLOCK_COEF = 0.1f; //����������� ����� ����� 1 �� �����,��������

}