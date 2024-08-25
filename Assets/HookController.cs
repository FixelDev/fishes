using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField]private int hookLevel;
    private bool isHookHasFish = false;
    private GameObject fishOnHook = null;
    private HookMovementController hookMovementController;
    private ReleaseHookController releaseHookController;
    private void Start() 
    {
        hookMovementController = GetComponent<HookMovementController>();
        releaseHookController = GetComponent<ReleaseHookController>();
    }


    public void CheckIfHookCanHandleCoughtFish()
    {
        FishController fishController = fishOnHook.GetComponent<FishController>();
        if(hookLevel < fishController.GetFishSize())
        {
            FishMovement fishMovement = fishOnHook.GetComponent<FishMovement>();
            fishMovement.ReleaseFish();
            fishOnHook = null;
        }


    }

    public void SetFishOnHook(GameObject fish)
    {
        fishOnHook = fish;
        CheckIfHookCanHandleCoughtFish();
    }

    public void CollectFish()
    {
        if(fishOnHook != null)
        {
            AddPoints();
            Destroy(fishOnHook);        
            fishOnHook = null;
        }

        PrepareHookForRelease();
            
    }

    private void AddPoints()
    {
        PointsController pointsController = FindObjectOfType<PointsController>();
        pointsController.AddPoints(fishOnHook.GetComponent<FishController>().GetFishValue());
    }

    public void PrepareHookForRelease()
    {
        releaseHookController.ResetHook();
        hookMovementController.ResetHook();
    }

    public void IncreaseHookLevel()
    {
        hookLevel++;
    }

    public int GetHookLevel()
    {
        return hookLevel;
    }



}
