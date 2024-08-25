using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUIController : MonoBehaviour
{
    [SerializeField] private Text pointsUI;

    private void Awake() 
    {
        PointsController pointsController = GetComponent<PointsController>();
        pointsController.OnPointsChangeEvent += SetNewAmountOfPoints;
    }

    private void SetNewAmountOfPoints(int newAmountOfPoints)
    {
        pointsUI.text = newAmountOfPoints.ToString();
    }
}
