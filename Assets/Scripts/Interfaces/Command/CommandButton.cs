//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;




public class ACommandButton: MonoBehaviour
{
    [SerializeField] private ACommandButtonState _buttonState;
    [SerializeField] private ICommandFabrica _commandFabrica;

    [SerializeField] private ACommandButtonState _unActiveState; //нелзя нажать stateID 0 
    [SerializeField] private ACommandButtonState _activeState; //можно нажать  stateID 1
    
    [SerializeField] private ACommandButtonState _coldownState;    //в кд  stateID 2

    private Image _image;


    [SerializeField] Sprite _spriteUnActiveState;
    [SerializeField] Sprite _spriteActiveState;
    [SerializeField] Sprite _spriteColdownState;

    private float _coldown; //кд кнопки
    private float ActualColdown;   //текущее кд кнопки


    private int k=0;

    public void SwapState(int state_id){
        switch(state_id){
            case 0:
                this._buttonState = this._unActiveState;
                break;
            case 1:
                this._buttonState = this._activeState;
                break;
            case 2:
                this._buttonState = this._coldownState;
                break;
        }
    }

    public void Show(){
        this._buttonState.ShowEffect();
    }


    public void ClickOnButton(){
        ICommand output = null;
        Debug.Log("Click on button");



        //this.GetComponent<Image>().sprite = ImageOne;
        //if(this._commandFabrica.CreateCommand(output)){//комманда создана
            //this.ActualColdown = this._coldown;
            //this.SwapState(2);
        //}
        //return output;
    }

    public void Awake(){

        this._image = this.GetComponent<Image>();

        this._activeState = null;
        this._unActiveState = null;
        this._coldownState = null;

        this.SwapState(0);
    }

    public void Update(){
        if(this.ActualColdown!=0){
            this.ActualColdown-=Time.deltaTime;
            if(this.ActualColdown<=0){
                this.ActualColdown = 0;
                this.SwapState(1);
            }
        }
    }
   
}
