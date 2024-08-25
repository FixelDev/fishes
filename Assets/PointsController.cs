using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private int currentAmountOfPoints = 0;

    public delegate void OnPointsChange(int points);
    public event OnPointsChange OnPointsChangeEvent;

    public void AddPoints(int pointsToAdd)
    {
        currentAmountOfPoints += pointsToAdd;
        OnPointsChangeEvent?.Invoke(currentAmountOfPoints);
    }
}
