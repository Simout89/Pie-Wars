using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timer;
    [SerializeField] public float LifeTime;
    [SerializeField] public float GameTime;
    void Start()
    {
        timer.text = LifeTime.ToString();
        GameTime+=1*Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
