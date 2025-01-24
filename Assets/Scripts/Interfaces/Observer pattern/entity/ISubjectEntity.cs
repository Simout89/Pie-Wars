

/// <summary>
/// только для юнитов/зданий. Отслеживает клики по ним
/// </summary>


public interface ISubjectEntity{
    public void AttachObserver(IObserverEntitys observer);//добавить слушателя
    public void DetachObserver(IObserverEntitys observer);//убрать слушателя
    public void NotifyObserversAboutClickLeft();//уведомить всех о клике ЛКМ
    public void NotifyObserversAboutClickLeftShift();//уведомить всех о клике ЛКМ+Sgift
}
