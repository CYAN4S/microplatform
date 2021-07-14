using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIController))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private UIController ui;
    
    public int CoinPoint { get; private set; }
    public bool IsCleared { get; private set; } = false;

    public bool isTouchEnabled = false;

    public void SetIsTouchEnabled(bool value) => isTouchEnabled = value;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;

        ui = GetComponent<UIController>();

        isTouchEnabled = Input.touchSupported;
    }

    public void OnCoinEarned()
    {
        CoinPoint++;
        ui.SetCoinCount(CoinPoint);
    }

    public void OnClear()
    {
        IsCleared = true;
        Invoke(nameof(ReloadScene), 3);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
