using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 Distance;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = PlayerTransform.position  + Distance;
    }
}
