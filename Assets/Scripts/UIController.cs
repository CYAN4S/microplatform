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
    public GameObject touches;
    
    public Toggle touchToggle;

    private void Awake()
    {
        touchToggle.onValueChanged.AddListener(value =>
        {
            GameManager.Instance.isTouchEnabled = value;
            touches.SetActive(value);
        });
    }

    public void SetCoinCount(int count = 0)
    {
        coinCount.text = count.ToString();
    }
}
