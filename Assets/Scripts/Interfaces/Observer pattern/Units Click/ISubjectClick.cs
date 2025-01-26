

/// <summary>
/// только для юнитов/зданий. Отслеживает клики по ним
/// </summary>


public interface ISubjectUnitsClick{
    public void AttachObserverUnitsClick(IObserverUnitsClick observer);//добавить слушателя
    public void DetachObserverUnitsClick(IObserverUnitsClick observer);//убрать слушателя
    public void NotifyObserversAboutClickLeft();//уведомить всех о клике ЛКМ
    public void NotifyObserversAboutClickLeftShift();//уведомить всех о клике ЛКМ+Sgift
}
