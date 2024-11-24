//все константы


static class Constants
{
    public const int FRACTION_NEUTRAL = 0;//НЕЙТРАЛЬНАЯ ФРАКЦИЯ(КАМНИ, ДЕРЕВЬЯ И ПОДОБНЫЕ)
    public const int FRACTION_PASTRY=1;//ТЕСТО              константы фракций
    public const int FRACTION_ICE = 2;//МОРОЖЕНОЕ
    public const int FRACTION_CHOCOLATE = 3;//шоколад       
    public const int FRACTION_SUGAR = 4;//сахар
    //константы состояния здания
    public const int BUILD_WORK_PASSIVE = 1;//ЗДАНИЕ РАБОТАЕТ ПАСИВНО
    public const int BUILD_STOP_PASSIVE = 2;//ЗДАНИЕ ПРОСТАИВАЕТ ПАСИВНО
    public const int BUILD_WORK_ACTIVELY = 3;//ЗДАНИЕ ЧТО-ТО ВЫПУСКАЕТ
    public const int BUILD_SHORTAGE = 4;//НЕХВАТКА РЕСУРСОВ
    //константы хп зданий в конфиге
    //типы зданий
    public const int BUILD_UNIT = 0; //ЗДАНИЕ ВЫПУСКАЕТ ОБЫЧНЫХ ЮНИТОВ
    public const int BUILD_TECHNIQUE_UNIT = 1; //ЗДАНИЕ ВЫПУСКАЕТ ТЕХНИКУ
    public const int BUILDE_SPECIAL_UNIT = 0; //ЗДАНИЕ ВЫПУСКАЕТ ОСОБЫХ ЮНИТОВ
    public const int BUILD_MINE = 3; //ЗДАНИЕ ШАХТЫ
    public const int BUILD_BARRACKS = 4; //ЗДАНИЕ БАРАКА
    public const int BUILD_PATROL = 5; //ЗДАНИЕ ДОЗОРНОГО ПУНКТА

    //константы юнитов


    //всякие разные Коэффициент
    public const float BLOCK_COEF = 0.1f; //коэффиценты блока урона 1 ед брони,проценты

}