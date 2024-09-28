using System;
using UnityEngine;

public interface IMediatorListener
{
    void OnEvent(GameObject gameObject);
}

public class StructureBreakMediator : MonoBehaviour
{
    public static StructureBreakMediator Instance { get; private set; }

    private event Action<GameObject> OnMessageReceived;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Register(IMediatorListener listener)
    {
        OnMessageReceived += listener.OnEvent;
    }

    public void Unregister(IMediatorListener listener)
    {
        OnMessageReceived -= listener.OnEvent;
    }

    public void SendMessage(GameObject gameObject)
    {
        OnMessageReceived?.Invoke(gameObject);
    }
}
