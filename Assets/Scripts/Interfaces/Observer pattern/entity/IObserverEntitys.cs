using System;

/// <summary>
/// только для тех, кто наблюдает за кликами по юнитам
/// </summary>


public interface IObserverEntitys{
    public void ClickOnEntitysLeft(Object obj);//функция, которая вызывается при клике ЛКМ на юнита/здание
    public void ClickOnEntitysShift(Object obj);//функция, которая вызывается при клике на ЛКМ+Shift на юнита/здание
}
