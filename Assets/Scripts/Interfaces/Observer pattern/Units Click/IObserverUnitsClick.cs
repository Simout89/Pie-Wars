using System;

/// <summary>
/// только для тех, кто наблюдает за кликами по юнитам
/// </summary>


public interface IObserverUnitsClick{
    public void ClickOnUnitLeft(Object obj);//функция, которая вызывается при клике ЛКМ на юнита/здание
    public void ClickOnUnitShift(Object obj);//функция, которая вызывается при клике на ЛКМ+Shift на юнита/здание
}
