using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIController))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    UIController ui;
    
    public int CoinPoint { get; private set; }
    public bool isCleared { get; private set; } = false;

    public bool isTouchEnabled = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;

        ui = GetComponent<UIController>();
    }

    public void OnCoinEarned()
    {
        CoinPoint++;
        ui.SetCoinCount(CoinPoint);
    }

    public void OnClear()
    {
        isCleared = true;
        Invoke(nameof(ReloadScene), 3);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OnToggleValueChanged(bool value)
    {
        
    }
}
