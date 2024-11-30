using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
    [Inject] SoundManager _soundManager;
    private AudioSource _audioSource;
    private float _globalVolume = 1;
    private float _volume = 1;
    
    [SerializeField] private SoundType _soundType;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _soundManager.volumeChanged += HandleVolumeChanged;
    }

    private void OnDisable()
    {
        _soundManager.volumeChanged -= HandleVolumeChanged;
    }

    private void HandleVolumeChanged(float volume, SoundType soundType)
    {
        if(!(soundType == _soundType || soundType == SoundType.Global))
            return;
        
        if(soundType == _soundType)
        {
            _volume = volume;
        }
        else if (soundType == SoundType.Global)
        {
            _globalVolume = volume;
        }
        _audioSource.volume = _volume * _globalVolume;
        
        Debug.Log($"SoundType: {_soundType} Глобал: {_globalVolume} Громокость: {_volume}");
    }
}
