using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private float fishSpeed;
    private float fishDirection;
    private Rigidbody2D rb;
    private int[] fishDirectionArray = new int[] {-1, 1};
    private FishController fishController;
    private bool isFishOnHook = false;
    private Transform hookTransform;

    private void Start() 
    {
        fishController = GetComponent<FishController>();
        rb = GetComponent<Rigidbody2D>();
        fishSpeed = RandomizeValue(2, 2);
        fishDirection = RandomizeValueFromArray(fishDirectionArray);
        transform.localScale = new Vector2(transform.localScale.x * -fishDirection, transform.localScale.y);
    }

    private int RandomizeValue(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    private int RandomizeValueFromArray(int[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    private void Update() 
    {   
        if(!isFishOnHook)
            rb.velocity = new Vector2(fishSpeed * fishDirection, 0);
        else
        {
            rb.velocity = new Vector2(0, 0);
            transform.parent = hookTransform;           
            transform.rotation = Quaternion.Euler(0, 0, -90 * -fishDirection);
            transform.position = new Vector2(hookTransform.transform.position.x, hookTransform.transform.position.y - 1f);
        }
            
    }

    public void ChangeFishDirection()
    {       
        fishDirection *= -1;
        FlipFishSprite();
    }

    private void FlipFishSprite()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    public void CatchFish(Transform hook)
    {
        isFishOnHook = true;
        hookTransform = hook;
    }

    public void ReleaseFish()
    {
        isFishOnHook = false;
        transform.parent = null;
    }

}
