using System;
using System.Collections.Generic;
using TMPro;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


//базовый класс для юнита, который ходит по земле//base class for a unit that walks on the ground
[Serializable]
public abstract class Unit: MonoBehaviour, IEntity, IDamageable
{
    [SerializeField] private UnityEngine.UI.Slider _healthSlider;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private Transform canvas;


    [Inject] protected SelectedEntitysController _selectedEntitysController;

    protected Outline outline;

    public EntityCfg Characteristics;

    private List<IObserverEntityClick> _observers = new();

    protected List<ICommand> _commandList = new();

    public Transform transformr { 
        get {return transform;} 
    }

    public float MaximumHealth { get; set; } = 50;
    public float CurrentHealth { get; set; }
    public void GetDamage(float damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"{gameObject.name} получен урон: {damage}");
        
        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
            Debug.Log($"{gameObject.name} умер");
            Destroy(gameObject);
        }
        
        if (_healthSlider != null)
        {
            _healthSlider.value = CurrentHealth;
        }
    }

    public event Action OnDeath;

    public int TeamId { get; set; } = 0;

    public EntityCfg _characteristics { 
        get {return Characteristics;}
       
    }

    public List<SkillBase> skills
    {
        get => _skills;
        set => _skills = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    [SerializeField] private string _name;

    [SerializeField] private List<SkillBase> _skills;
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){

        //для обработки клика на юнит//to handle clicks on a unit
        if(Input.GetKey(KeyCode.LeftShift)){ //клик по юниту лкм+shift
             if(eventData.button==PointerEventData.InputButton.Left){
                NotifyObserversAboutClickLeftShift();
            }
             return;
        }
        if(eventData.button==PointerEventData.InputButton.Left){//клик по юниту лкм
                NotifyObserversAboutClickLeft();
        }



    }

    public bool ExecuteCommand(ICommand command){
        return command.Execute();
    }

    public void AddCommand(ICommand command){
        _commandList.Add(command);
    }

    public void RemoveCommand(ICommand command){
        this._commandList.Remove(command);
       
    }

    public void ClearCommandList(){
        _commandList.Clear();
    }

    public void AddOutline(){
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0.0f;
    }

    public void OnOutline(){
        outline.OutlineWidth = 5f;
    }

    public void OffOutline(){
        outline.OutlineWidth = 0.0f;
    }

    public void InitCharacteristics(){
        throw new NotImplementedException();
    }

    public void AttachObserverUnitsClick(IObserverEntityClick observer){
        _observers.Add(observer);
    }

    public void DetachObserverUnitsClick(IObserverEntityClick observer){
        if(_observers.Contains(observer)){
            _observers.Remove(observer);
        }
    }

    public void NotifyObserversAboutClickLeft(){
        foreach(IObserverEntityClick obs in _observers){obs.ClickOnEntityLeft(this);}
    }

    public void NotifyObserversAboutClickLeftShift(){
        foreach(IObserverEntityClick obs in _observers){obs.ClickOnEntityLeftShift(this);}
    }

    public void Move(Vector3 target){
        this.transform.LookAt(target);
    
        // Проверяем, что Characteristics инициализированы
        float speed = 5f; // значение по умолчанию
    
        if(this.Characteristics != null)
        {
            speed = (float)this.Characteristics.SP;
        }
        else
        {
            Debug.LogWarning($"Characteristics не инициализированы для {gameObject.name}, используется скорость по умолчанию: {speed}");
        }
    
        float moveDistance = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, moveDistance);
    }



    public void Awake(){
        this.AddOutline();
        this._selectedEntitysController.SubscribeEntitysClick(this);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

        CurrentHealth = MaximumHealth;
        if (_healthSlider != null)
        {
            _healthSlider.maxValue = MaximumHealth;
            _healthSlider.value = CurrentHealth;
        }

        if (_textName != null)
        {
            _textName.text = Name;
        }
    }

    public void Update(){
        if (canvas != null)
        {
            canvas.transform.LookAt(Camera.main.transform);
        }
        
        if(this._commandList.Count!=0){
           
           
            //foreach(ICommand command in this._commandList){
                if(this._commandList[0].Execute()){      //КОММАНДА ВЫПОЛНИЛАСЬ
                    this._commandList.Remove(this._commandList[0]); 
                }
                
            //}

        }

    }

   
}

public interface IDamageable
{
    public float MaximumHealth { get; set; }
    public float CurrentHealth { get; set; }

    public void GetDamage(float damage);

    public event Action OnDeath;
}
