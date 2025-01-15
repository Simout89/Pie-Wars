using System;
using UnityEngine;

namespace _Script.Mediator
{
    public class SoundMediator: MonoBehaviour
    {
        public event Action<float> OnVolumeChanged;
    }
}