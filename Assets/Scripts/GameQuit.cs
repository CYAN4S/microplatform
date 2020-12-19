using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    [SerializeField] private GameObject messageAndroid;
    [SerializeField] private GameObject messageWindows;

    private GameObject _quitMessage;
    private float _firstQuitTime = -3f;
    
    private void Awake()
    {
        _quitMessage = Application.platform == RuntimePlatform.Android ? messageAndroid : messageWindows;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_firstQuitTime + 3f >= Time.time)
            {
                Application.Quit();
                return;
            }
            
            _quitMessage.SetActive(true);
            StartCoroutine(nameof(HideMessage));
            _firstQuitTime = Time.time;
        }
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3f);
        _quitMessage.SetActive(false);
    }
}
