using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRoadLine : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        Vector3 startPos = new Vector3(startPosition.position.x, startPosition.position.y, 0);
        Vector3 endPos = new Vector3(endPosition.position.x, endPosition.position.y, 0);

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
