using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public event Action<float, SoundType> volumeChanged;
    
    private SoundType soundType;
    

    public void sliderChangeValue(float volume)
    {
        volumeChanged?.Invoke(volume, soundType);
    }
}

public enum SoundType
{
    Music,
    Effect,
    Entity,
    Alarms,
    Voices
}
