

/// <summary>
/// только для юнитов/зданий. Отслеживает клики по ним
/// </summary>


public interface ISubjecEntityClick{
    public void AttachObserverUnitsClick(IObserverEntityClick observer);//добавить слушателя
    public void DetachObserverUnitsClick(IObserverEntityClick observer);//убрать слушателя
    public void NotifyObserversAboutClickLeft();//уведомить всех о клике ЛКМ
    public void NotifyObserversAboutClickLeftShift();//уведомить всех о клике ЛКМ+Sgift
}
