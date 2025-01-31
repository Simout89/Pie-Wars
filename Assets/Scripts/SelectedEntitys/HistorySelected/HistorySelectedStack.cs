using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
public class HistorySelectedStack
{

   [SerializeField]  private List<IEntity>[] _items;
    [SerializeField]private int _count=0;//текущее кол-во элементов
    public const int _maxCount  = Constants.HISTORY_SELECTED_UNITS;
    private bool _work = false;

    public HistorySelectedStack(){
        _items = new List<IEntity>[_maxCount];
        _count=-1;
    }


    public void Add(List<IEntity> item){
        Debug.Log(_items.Length);
        if (_count == _items.Length-1){
            _items[_count-1] = new(item);
            Debug.Log(_items[_count-1].Count);

        }else{
            _count+=1;
            _items[_count] = new(item);
            Debug.Log(_items[_count].Count);
        }
    }
    public List<IEntity> Get(){

        if(this._count == 0){
            return new List<IEntity>();
        }else{
            List<IEntity> item = _items[_count];
            _items[_count] = default(List<IEntity>); // сбрасываем ссылку
            Debug.Log(item.Count);
            _count-=1;
            return item;
        }

    }

}