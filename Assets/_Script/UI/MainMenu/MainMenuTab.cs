using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuTab : MonoBehaviour
{
    [SerializeField] private int AnimatorInt;

    [SerializeField] private Animator _animator;

    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _openButton.onClick.AddListener(HandleOnClickOpen);
        _closeButton.onClick.AddListener(HandleOnClickClose);
    }

    private void HandleOnClickClose()
    {
        _animator.SetTrigger("Trigger");
    }

    private void HandleOnClickOpen()
    {
        _animator.SetTrigger("Trigger");
        _animator.SetInteger("choose", AnimatorInt);
    }
}