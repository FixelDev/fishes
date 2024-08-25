using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform hookTransform;

    private void Update() 
    {
        transform.position = new Vector3(hookTransform.position.x + 4.5f, hookTransform.position.y, -10);
    }
}
