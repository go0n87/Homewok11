using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - PlayerTransform.transform.position;
    }
    void Update()
    {
        transform.position = PlayerTransform.position + _offset;
    }
}