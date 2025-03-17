using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    private AudioMixer audioMixer;
    
    private string mixerName;

    public void Initialize(AudioMixer audioMixer, string mixerName)
    {
        this.audioMixer = audioMixer;
        this.mixerName = mixerName;
        slider.onValueChanged.AddListener(HandleSliderValueChanged);

        float value;
        this.audioMixer.GetFloat(mixerName, out value);
        slider.value = Mathf.InverseLerp(-80f, 0f, value);
    }

    private void HandleSliderValueChanged(float arg0)
    {
        float volume = Mathf.Lerp(-80f, 0f, arg0);
        Debug.Log($"HandleSliderValueChanged {mixerName}");
        audioMixer.SetFloat(mixerName, volume);
    }
}
