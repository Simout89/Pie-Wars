using UnityEngine;

public interface ISubjectMap{
    public void AttachObserver(IObserverMap observer);//добавить слушателя
    public void DetachObserver(IObserverMap observer);//убрать слушателя
    public void NotifyObserversAboutClickLeft();
    public void NotifyObserversAboutClickRight();
}