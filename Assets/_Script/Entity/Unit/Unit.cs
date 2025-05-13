using System;
using System.Collections.Generic;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
public abstract class Unit : MonoBehaviour, IEntity
{

    [Inject] protected SelectedEntitysController _selectedEntitysController;

    protected Outline outline;

    public EntityCfg Characteristics;

    private List<IObserverEntityClick> _observers = new();

    protected List<ICommand> _commandList = new();
    protected List<ICommand> _staticCommandList = new(); //commands that are always executed

    public Transform transformr {
        get { return transform; }
    }
    public EntityCfg _characteristics {
        get { return Characteristics; }

    }

    private int _teamNum;
    public int teamNum
    {
        get
        {
            return _teamNum;
        }
        set
        {
            _teamNum = value;
        }
    }



    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData) {

        //для обработки клика на юнит//to handle clicks on a unit
        if (Input.GetKey(KeyCode.LeftShift)) { //клик по юниту лкм+shift
            if (eventData.button == PointerEventData.InputButton.Left) {
                NotifyObserversAboutClickLeftShift();
            }
            return;
        }
        if (eventData.button == PointerEventData.InputButton.Left) {//клик по юниту лкм
            NotifyObserversAboutClickLeft();
        }



    }


    public virtual void InitUnit()//called when a building spawns to initialize static commands and others
    {

    }


    public bool ExecuteCommand(ICommand command) {
        return command.Execute();
    }

    public void AddCommand(ICommand command) {
        _commandList.Add(command);
    }

    public void RemoveCommand(ICommand command) {
        this._commandList.Remove(command);

    }

    public void ClearCommandList() {
        _commandList.Clear();
    }

    public void AddOutline() {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0.0f;
    }

    public void OnOutline() {
        outline.OutlineWidth = 5f;
    }

    public void OffOutline() {
        outline.OutlineWidth = 0.0f;
    }

    public void InitCharacteristics() {
        throw new NotImplementedException();
    }

    public void AttachObserverUnitsClick(IObserverEntityClick observer) {
        _observers.Add(observer);
    }

    public void DetachObserverUnitsClick(IObserverEntityClick observer) {
        if (_observers.Contains(observer)) {
            _observers.Remove(observer);
        }
    }

    public void NotifyObserversAboutClickLeft() {
        foreach (IObserverEntityClick obs in _observers) { obs.ClickOnEntityLeft(this); }
    }

    public void NotifyObserversAboutClickLeftShift() {
        foreach (IObserverEntityClick obs in _observers) { obs.ClickOnEntityLeftShift(this); }
    }

    public void Move(Vector3 target) {
        this.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);//(float)this.Characteristics.SP);
    }

    public virtual void TakeDamage(double damage)
    {
        this.Characteristics.HP -= damage;
        if (Characteristics.HP <= 0)
        {

            Destroy(gameObject);
        }

        
    }

    public void Awake(){
        this.AddOutline();
        //this._selectedEntitysController.SubscribeEntitysClick(this);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
    protected virtual void Start()
    {
        
        this._selectedEntitysController.SubscribeEntitysClick(this);  // Вызов после инъекции
        
    }




    protected virtual void Update(){


        //Debug.Log(teamNum);

        if(this._commandList.Count!=0){

                if(this._commandList[0].Execute()){      //КОММАНДА ВЫПОЛНИЛАСЬ
                    
                    this._commandList.Remove(this._commandList[0]); 
                }

        }

        if (this._staticCommandList.Count != 0)
        {

            for (int i = 0; i < this._staticCommandList.Count; i++)
            {
                this._staticCommandList[i].Execute();
            }

        }

    }

   
}
