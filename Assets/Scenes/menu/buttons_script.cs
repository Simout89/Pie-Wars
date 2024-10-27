using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons_script : MonoBehaviour
{
    public GameObject TargetObj; //�� ������ ���������� � ���������� ���� ������ ������
    private menu_ui_controller _actionTarget; //������ SomeMonoBehavior  �� �������� �������
    
    private void Start()
    {
        _actionTarget = TargetObj.GetComponent<menu_ui_controller>();
    }
    public void trigger(int for_example)
    {
        _actionTarget.Animator_trigger(for_example);
    }
}