using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coinCount;

    public GameObject pause;
    public GameObject clear;
    public GameObject touchUI;
    
    public Toggle touchToggle;

    private void Awake()
    {
        touchToggle.isOn = Input.touchSupported;
        touchUI.SetActive(Input.touchSupported);
    }

    public void SetCoinCount(int count = 0)
    {
        coinCount.text = count.ToString();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(!pause.activeSelf);
            Debug.Log("VAR");
        }
    }
}
