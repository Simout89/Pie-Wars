using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Build : MonoBehaviour, IEntity
{
    [Inject] protected SelectedEntitysController _selectedEntitysController;

    protected Outline outline;

    public EntityCfg Characteristics;

    protected List<ICommand> _commandList = new();
    protected List<ICommand> _staticCommandList = new(); //commands that are always executed

    public Transform transformr
    {
        get { return transform; }
    }
    public EntityCfg _characteristics
    {
        get { return Characteristics; }

    }


    public void AddCommand(ICommand command)
    {
        _commandList.Add(command);
    }

    public void AddOutline()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 0.0f;
    }

    public void AttachObserverUnitsClick(IObserverEntityClick observer)
    {
        
    }

    public void ClearCommandList()
    {
        
    }

    public void DetachObserverUnitsClick(IObserverEntityClick observer)
    {
        
    }

    public bool ExecuteCommand(ICommand command)
    {
        return true;
    }

    public void InitCharacteristics()
    {
        
    }

    public void Move(Vector3 target)
    {
        
    }

    public void NotifyObserversAboutClickLeft()
    {
        
    }

    public void NotifyObserversAboutClickLeftShift()
    {
        
    }

    public void OffOutline()
    {
        outline.OutlineWidth = 0.0f;
    }

    public void OnOutline()
    {
        outline.OutlineWidth = 5f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void RemoveCommand(ICommand command)
    {
        this._commandList.Remove(command);

    }



    public virtual void InitBuild()//called when a building spawns to initialize static commands and others
    { 

    }



    public void Awake()
    {
        this.AddOutline();
        this._selectedEntitysController.SubscribeEntitysClick(this);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        this.InitBuild();
    }

    public void Update()
    {
        if (this._commandList.Count != 0)
        {
            //foreach(ICommand command in this._commandList){
            if (this._commandList[0].Execute())
            {      // ŒÃÃ¿Õƒ¿ ¬€œŒÀÕ»À¿—‹
                this._commandList.Remove(this._commandList[0]);
            }

            //}
        }

        if (this._staticCommandList.Count != 0) {

            for (int i = 0; i < this._staticCommandList.Count; i++) {
                this._staticCommandList[i].Execute();
            }

        }

    }
}
