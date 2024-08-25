using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendHookToStartPositionCOntroller : MonoBehaviour
{
    [SerializeField] private Transform hookStartPosition;
    private bool isHookIsPullingBack;
    private bool oneTime = false;
    private float currentLerpTime = 0.0f;
    private float lerpTime = 2f;
    private Vector3 currentHookPosition;
    private HookController hookController;
    private HookMovementController hookMovementController;

    private void Start() 
    {
        hookMovementController = GetComponent<HookMovementController>();
        hookController = GetComponent<HookController>();
    }

    private void Update() 
    {
        if(isHookIsPullingBack)
            StartLerp();
        else
            currentLerpTime = 0.0f;
    }

    private void StartLerp()
    {
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime >= lerpTime)
            currentLerpTime = lerpTime;
        float percentage = currentLerpTime / lerpTime;
        Vector3 newHookPosition = Vector3.Lerp(currentHookPosition, hookStartPosition.position, percentage);
        transform.position = newHookPosition;
        
        if(newHookPosition == hookStartPosition.position)
        {
            hookMovementController.ChangeGravityOfHook(0);
            hookController.CollectFish();
            isHookIsPullingBack = false;
            oneTime = false;
        }
            

    }

    public void SendHookToStartPosition()
    {
        if(!oneTime)
        {
            isHookIsPullingBack = true;
            currentHookPosition = transform.position;
            oneTime = true;
        }
        
    }

    public bool CheckIfHookIsPullingBack()
    {
        return isHookIsPullingBack;
    }
}
