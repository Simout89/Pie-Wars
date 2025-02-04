//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;




public class SkillButton: MonoBehaviour
{
    [SerializeField] private ICommandFabrica _commandFabrica;


    [SerializeField] bool isActive = true;
    [SerializeField] Sprite _baseSprite;

    private Image _image;
   

    private float _coldown; //кд кнопки
    private float ActualColdown;   //текущее кд кнопки


    private void ShowActive(){
        this._image.color = Color.white;
    }
    private void ShowUnActive(){
        this._image.color = Color.gray;
    }

    private void ShowColdawn(){
        this._image.color = Color.red;
    }


    public void ClickOnButton(){
        Debug.Log("Click on button");

        if(isActive){
            
            //перевести кнопку в кд если было созданна комманда
            this.isActive = false;
            this.ActualColdown = this._coldown;
            this.ShowColdawn();

        }else{
            Debug.Log("Button in unActive");
        }


    }

    public void Awake(){

        this._image = this.GetComponent<Image>();
        this._coldown = 5;

    }

    public void Update(){
        if(this.ActualColdown!=0){
            this.ActualColdown-=Time.deltaTime;
            if(this.ActualColdown<=0){
                this.ActualColdown = 0;
                this.isActive = true;
                this.ShowActive();
                
            }
        }
    }
   
}
