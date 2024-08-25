using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollisionController : MonoBehaviour
{
    private FishMovement fishMovement;

    private void Start() 
    {
        fishMovement = GetComponent<FishMovement>();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bound")
        {
            fishMovement.ChangeFishDirection();
        }
    }
    
}
