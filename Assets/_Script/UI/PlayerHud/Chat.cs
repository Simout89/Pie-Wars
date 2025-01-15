using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Script.System
{
    public class Chat: MonoBehaviour
    {
        [SerializeField] private GameObject messagePrefab;
        [SerializeField] private Transform contentTransform;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private ScrollRect scrollRect;

        private List<GameObject> _messages = new List<GameObject>();
        public event Action<string> onMessageSend; 

        private void Awake()
        {
            inputField.onSubmit.AddListener(HandleSubmit);
        }

        private void HandleSubmit(string arg0)
        {
            if (arg0 == "")
                return;

            GameObject message = Instantiate(messagePrefab, contentTransform);
            _messages.Add(message);

            if (message.TryGetComponent(out TMP_Text text))
                text.text = arg0;

            inputField.text = "";

            Canvas.ForceUpdateCanvases();

            scrollRect.verticalNormalizedPosition = 0f;
            
            inputField.ActivateInputField();
            
            onMessageSend?.Invoke(arg0);
        }
        
        /*private class Message
        {
            public string Text;

            public Message(string text, string author)
            {
                Text = text;
            }
        }*/

    }
}