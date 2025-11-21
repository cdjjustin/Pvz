using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int initSunCount = 50;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SunManager.Instance.AddSun(initSunCount);     
    }
}