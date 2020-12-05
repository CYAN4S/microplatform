using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallexEffect : MonoBehaviour
{
    public Transform targetTransform;
    public Vector2 effectValue;

    private Vector3 initPos;
    private Vector3 targetPos;
    private Vector3 delta;

    private void Awake()
    {
        initPos = transform.position;
    }

    private void LateUpdate()
    {
        targetPos = targetTransform.position;
        delta.x = targetPos.x * effectValue.x;
        delta.y = targetPos.y * effectValue.y;
        transform.position = initPos + delta;
    }
}
