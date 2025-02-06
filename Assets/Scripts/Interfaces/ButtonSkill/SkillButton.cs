//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;




public class SkillButton: MonoBehaviour
{

    [SerializeField] private EntitysController _entitysController;

    [SerializeField] private ICommandFabrica _commandFabrica;


    [SerializeField] bool isActive = true;
    [SerializeField] bool isColdown = true;
    [SerializeField] Sprite _baseSprite;

    private Image _image;
   

    private float _coldown; //кд кнопки
    private float ActualColdown;   //текущее кд кнопки


    private void Show(){

        if(this.isColdown){
            this._image.material.SetFloat("_FillAmount",this.ActualColdown/this._coldown);
        }
        else{
            if(isActive){
                this._image.material.SetFloat("_FillAmount",0);
            }
            else{
                this._image.material.SetFloat("_FillAmount",1);
            }
        }


        
    }


    public void ClickOnButton(){
        Debug.Log("Click on button");

        if(isActive){
            ICommand command = null;
            isActive = false;
            this.ActualColdown = this._coldown;
            this.isColdown = true;

            if(this._commandFabrica.CreateCommand(command)){

                if (Input.GetKey(KeyCode.LeftShift)){ 
                    _entitysController.AddCommand(command);
                }
                else{
                    _entitysController.GiveCommand(command);
                }
            }
            else{

            }

        }



    }

    public void Awake(){

        this._image = this.GetComponent<Image>();
        this._coldown = 5;

    }

    public void Update(){

        this.ActualColdown-=Time.deltaTime;

        if(this.ActualColdown<=0){this.ActualColdown = 0;}
        
        if(this.ActualColdown == 0){
            this.isActive = true;
            this.isColdown = false;
        }
        else{
            isActive = false;
            this.isColdown = true;
        }
        this.Show();
        
    }
   
}
