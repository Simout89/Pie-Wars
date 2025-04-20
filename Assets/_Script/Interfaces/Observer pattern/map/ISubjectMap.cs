using UnityEngine;

public interface ISubjectMap{
    public void AttachObserverMap(IObserverMap observer);//добавить слушателя
    public void DetachObserverMap(IObserverMap observer);//убрать слушателя
    public void NotifyObserversAboutClickLeft();
    public void NotifyObserversAboutClickRight();
}