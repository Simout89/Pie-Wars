using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
    [Inject] SoundManager _soundManager;
    private AudioSource audioSource;
    
    [SerializeField] private SoundType _soundType;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _soundManager.volumeChanged += HandleVolumeChanged;
    }

    private void HandleVolumeChanged(float volume, SoundType soundType)
    {
        if(soundType == _soundType)
            audioSource.volume = volume;
    }
}
