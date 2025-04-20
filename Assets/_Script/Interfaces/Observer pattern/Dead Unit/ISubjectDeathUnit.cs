using UnityEngine;

public interface ISubjectDeathEntity
{
    //public void AttachObserver(IObserverEntitys observer);//добавить слушателя
    //public void DetachObserver(IObserverEntitys observer);//убрать слушателя
    public void NotifyObserversAboutClickLeft();//уведомить всех о клике ЛКМ
    public void NotifyObserversAboutClickLeftShift();//уведомить всех о клике ЛКМ+Sgift
}
