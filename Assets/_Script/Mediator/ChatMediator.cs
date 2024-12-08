using System;
using UnityEngine;

namespace _Script.Mediator
{
    public class ChatMediator: MonoBehaviour
    {
        public event Action<string> OnChatMessage;
    }
}