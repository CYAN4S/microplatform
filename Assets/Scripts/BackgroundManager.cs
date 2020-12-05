using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    

    Transform tf;

    private void Awake() {
        tf = GetComponent<Transform>();
    }
}
