using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerSlider audioMixerSliderPrefab;
    [SerializeField] private Transform contentTransform;
    private void Awake()
    {
        AudioMixerGroup[] groups = audioMixer.FindMatchingGroups("");

        foreach (var VARIABLE in groups)
        {
            audioMixer.SetFloat(VARIABLE.name, 1);
            Instantiate(audioMixerSliderPrefab, contentTransform).Initialize(audioMixer, VARIABLE.name + "Volume");
        }
    }
}
