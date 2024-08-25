using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollisionController : MonoBehaviour
{   
    private HookMovementController floatMovementController;
    private ReleaseHookController releaseHookController;
    private HookController hookController;
    private SendHookToStartPositionCOntroller sendHookToStartPositionCOntroller;

    private void Start() 
    {
        sendHookToStartPositionCOntroller = GetComponent<SendHookToStartPositionCOntroller>();
        hookController = GetComponent<HookController>();
        floatMovementController = GetComponent<HookMovementController>();
        releaseHookController = GetComponent<ReleaseHookController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Water")
        {
            floatMovementController.OnCollisionWithWater();
        }
        if(other.tag == "Fish")
        {
            if(!sendHookToStartPositionCOntroller.CheckIfHookIsPullingBack())
            {
                CatchFish(other);
                SendHookToStartPositionCOntroller();    
            }
               
        }
    }

    private void CatchFish(Collider2D fish)
    {
        FishMovement fishMovement = fish.GetComponent<FishMovement>();
        fishMovement.CatchFish(transform);
        hookController.SetFishOnHook(fish.gameObject);
    }

    private void SendHookToStartPositionCOntroller()
    { 
        sendHookToStartPositionCOntroller.SendHookToStartPosition();
    }

}
