using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]private int fishSize;
    [SerializeField] private int fishValue;

    public int GetFishSize()
    {
        return fishSize;
    }
    public int GetFishValue()
    {
        return fishValue;
    }
}
