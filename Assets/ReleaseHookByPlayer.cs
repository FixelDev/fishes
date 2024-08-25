using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseHookByPlayer : MonoBehaviour
{
    private ReleaseHookController releaseHookController;

    private void Start() 
    {
        releaseHookController = FindObjectOfType<ReleaseHookController>();
    }

    public void ReleaseHook()
    {
        releaseHookController.ReleaseFloat();
    }
}
