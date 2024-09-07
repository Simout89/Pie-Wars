using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected int TeamId;
    
    [SerializeField] protected AudioClip[] Sounds;
    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySoundOnSpawn()
    {
        audioSource.PlayOneShot(Sounds[0]);
    }
    // смерть
}
