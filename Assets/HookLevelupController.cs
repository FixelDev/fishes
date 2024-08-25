using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLevelupController : MonoBehaviour
{
    private int neededPointsToLevelupHook = 1;
    private HookController hookController;
    [SerializeField] private List<Sprite> fishingRods;
    [SerializeField] private SpriteRenderer originalFishingRoad;

    private void Awake() 
    {
        PointsController pointsController = FindObjectOfType<PointsController>();
        pointsController.OnPointsChangeEvent += CheckIfHookCanLevelUp;
    }

    private void Start()
    {
        hookController = GetComponent<HookController>();
    }

    private void CheckIfHookCanLevelUp(int currentAmountOfPoints)
    {
        if(currentAmountOfPoints >= neededPointsToLevelupHook)
        {          
            hookController.IncreaseHookLevel();
            ChangeFishingRodSprite();
            CalculateNewAmountOfNeededPointsToLevelup();
        }
                 
    }

    private void ChangeFishingRodSprite()
    {
        string newFishingRoadName = "fishingRod" + hookController.GetHookLevel();
        Sprite foundFishingRoad = fishingRods.Find(fishingRod => fishingRod.name == newFishingRoadName);
        if(foundFishingRoad != null)
            originalFishingRoad.sprite = foundFishingRoad;
    }

    private void CalculateNewAmountOfNeededPointsToLevelup()
    {
        int currentNeededPointsToLevelup = neededPointsToLevelupHook;
        neededPointsToLevelupHook += currentNeededPointsToLevelup;
    }
}
