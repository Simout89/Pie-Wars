using System;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float Health;
    protected float MaxHealth;
    [HideInInspector] public int TeamId;
    
    [SerializeField] protected AudioClip[] Sounds;
    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MaxHealth = Health;
    }
    
    public void PlaySoundOnSpawn()
    {
        audioSource.PlayOneShot(Sounds[0]);
    }

    internal void Move()
    {
        throw new NotImplementedException();
    }
    // смерть
}
